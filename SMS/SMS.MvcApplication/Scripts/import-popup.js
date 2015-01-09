function ImportPopup(id, storedProcedure) {
    var root = this;
    this.popupId = '#' + id;
    this.storedProcedure = storedProcedure;
    var $dialogContainer;
    var $detachedChildren;

    var handsonTable;

    $(root.popupId).dialog({
        autoOpen: false,
        closeOnEscape: true,
        width: "90%",
        height: 700,
        modal: true,
        resizable: false,
        close: function () {
            $('#fileupload').val('');
            $('#dataReview').html('');
        },
        open: function () {
            $detachedChildren.appendTo($dialogContainer);
        }
    });

    this.OpenPopup = function () {

        $(root.popupId + ' .process').button({
            icons: {
                primary: "ui-icon-transferthick-e-w"
            }
        }).click(function () {
            var data = handsonTable.getData();
            var cellOption = [];
            var obj = null;
            var errorColor = 'red';
            var errorMessage = '';
            
            for (var i = 0; i < data.length; i++) {
                obj = data[i];
                
                /*
                $.ajax({
                    type: 'POST',
                    async: false,
                    url: '',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ listLabels: data })
                }).done(function (result) {
                    if (result.Success) {
                        if (result.Data.ErrorMessage != "") {
                            cellOption[cellOption.length] = {
                                row: i,
                                col: 0,
                                renderer: function(instance, td, row, col, prop, value, cellProperties) {
                                    Handsontable.renderers.TextRenderer.apply(this, arguments);
                                    td.style.backgroundColor = errorColor;
                                    $(td).parent().prop('title', errorMessage);
                                }
                            };
                        }
                    } else {
                        errorMessage = "Can't import data right now. Please try again later.";

                        cellOption[cellOption.length] = {
                            row: i,
                            col: 0,
                            renderer: function (instance, td, row, col, prop, value, cellProperties) {
                                Handsontable.renderers.TextRenderer.apply(this, arguments);
                                td.style.backgroundColor = errorColor;
                                $(td).parent().prop('title', errorMessage);
                            }
                        };
                    }
                });
                */ 
            }
            
            handsonTable.updateSettings({
                comments: true,
                cell: cellOption,
                fixedColumnsLeft: 1
            });

            $('#dataReview').tooltip({
                show: {
                    effect: "slideDown",
                    delay: 250
                },
                track: true
            });
            return false;
        });

        $(root.popupId + ' .popupClose').button({
            icons: {
                primary: "ui-icon-close"
            }
        }).click(function() {
            $(root.popupId).dialog('close');
            return false;
        });
        
        $dialogContainer = $(root.popupId);
        $detachedChildren = $dialogContainer.children().detach();
        $(root.popupId).dialog("open");
        setHeightPopupContent(root.popupId);

        var contentHeight = $(root.popupId + ' .popup-content').height();
        var height = $(root.popupId + ' .marginBottom5px').outerHeight();

        var targetHeight = contentHeight - height - 10;

        $(root.popupId + ' #dataReview').css('height', targetHeight + 'px');
    };
    
    var X = XLS;
    var XW = {
        /* worker message */
        msg: 'xls',
        /* worker scripts */
        rABS: './xlsworker2.js',
        norABS: './xlsworker1.js',
        noxfer: './xlsworker.js'
    };

    var rABS = false;
    var use_worker = false;
    var transferable = use_worker;

    function fixdata(data) {
        var o = "", l = 0, w = 10240;
        for (; l < data.byteLength / w; ++l) o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w, l * w + w)));
        o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w)));
        return o;
    }

    function ab2str(data) {
        var o = "", l = 0, w = 10240;
        for (; l < data.byteLength / w; ++l) o += String.fromCharCode.apply(null, new Uint16Array(data.slice(l * w, l * w + w)));
        o += String.fromCharCode.apply(null, new Uint16Array(data.slice(l * w)));
        return o;
    }

    function s2ab(s) {
        var b = new ArrayBuffer(s.length * 2), v = new Uint16Array(b);
        for (var i = 0; i != s.length; ++i) v[i] = s.charCodeAt(i);
        return [v, b];
    }

    function xw_noxfer(data, cb) {
        var worker = new Worker(XW.noxfer);
        worker.onmessage = function (e) {
            switch (e.data.t) {
                case 'ready': break;
                case 'e': console.error(e.data.d); break;
                case XW.msg: cb(JSON.parse(e.data.d)); break;
            }
        };
        var arr = rABS ? data : btoa(fixdata(data));
        worker.postMessage({ d: arr, b: rABS });
    }

    function xw_xfer(data, cb) {
        var worker = new Worker(rABS ? XW.rABS : XW.norABS);
        worker.onmessage = function (e) {
            switch (e.data.t) {
                case 'ready': break;
                case 'e': console.error(e.data.d); break;
                default: var xx = ab2str(e.data).replace(/\n/g, "\\n").replace(/\r/g, "\\r"); console.log("done"); cb(JSON.parse(xx)); break;
            }
        };
        if (rABS) {
            var val = s2ab(data);
            worker.postMessage(val[1], [val[1]]);
        } else {
            worker.postMessage(data, [data]);
        }
    }

    function xw(data, cb) {
        transferable = document.getElementsByName("xferable")[0].checked;
        if (transferable) xw_xfer(data, cb);
        else xw_noxfer(data, cb);
    }
    
    function to_json(workbook) {
        var result = {};
        workbook.SheetNames.forEach(function (sheetName) {
            var roa = XLS.utils.sheet_to_row_object_array(workbook.Sheets[sheetName]);
            if (roa.length > 0) {
                result["Data"] = roa;
            }
        });
        return result;
    }
    
    var xlf = document.getElementById('fileupload');
    function handleFile(e) {
        rABS = false;
        use_worker = false;
        var files = e.target.files;
        var f = files[0];
        {
            var reader = new FileReader();
            var name = f.name;
            reader.onload = function (e) {
                if (typeof console !== 'undefined') console.log("onload", new Date(), rABS, use_worker);
                var data = e.target.result;
                if (use_worker) {
                    xw(data, process_wb);
                } else {
                    var wb;
                    if (rABS) {
                        wb = X.read(data, { type: 'binary' });
                    } else {
                        var arr = fixdata(data);
                        wb = X.read(btoa(arr), { type: 'base64' });
                    }
                    process_wb(wb);
                }
            };
            if (rABS) reader.readAsBinaryString(f);
            else reader.readAsArrayBuffer(f);
        }
    }
    
    if (xlf.addEventListener) xlf.addEventListener('change', handleFile, false);

    function process_wb(wb) {
        var result = to_json(wb);

        $('#dataReview').html('');
        
        var container = document.getElementById('dataReview');

        handsonTable = Handsontable(container,
        {
            data: result.Data,
            minSpareRows: 0,
            currentRowClassName: 'currentRow',
            currentColClassName: 'currentCol',
            autoWrapRow: true,
            colHeaders: true,
            rowHeaders: false,
            contextMenu: false
        });
    }
}

