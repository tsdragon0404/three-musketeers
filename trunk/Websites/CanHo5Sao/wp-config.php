<?php
/**
 * The base configurations of the WordPress.
 *
 * This file has the following configurations: MySQL settings, Table Prefix,
 * Secret Keys, WordPress Language, and ABSPATH. You can find more information
 * by visiting {@link http://codex.wordpress.org/Editing_wp-config.php Editing
 * wp-config.php} Codex page. You can get the MySQL settings from your web host.
 *
 * This file is used by the wp-config.php creation script during the
 * installation. You don't have to use the web site, you can just copy this file
 * to "wp-config.php" and fill in the values.
 *
 * @package WordPress
 */

// ** MySQL settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define('DB_NAME', 'canho5sao');

/** MySQL database username */
define('DB_USER', 'root');

/** MySQL database password */
define('DB_PASSWORD', '');

/** MySQL hostname */
define('DB_HOST', 'localhost');

/** Database Charset to use in creating database tables. */
define('DB_CHARSET', 'utf8');

/** The Database Collate type. Don't change this if in doubt. */
define('DB_COLLATE', '');

/**#@+
 * Authentication Unique Keys and Salts.
 *
 * Change these to different unique phrases!
 * You can generate these using the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}
 * You can change these at any point in time to invalidate all existing cookies. This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define('AUTH_KEY',         '{wKNi7)cvllHuI%f.g.7qAB<=6|ehKByENIF:P6Eq5i*;kh7o7F|<I{Th}T`>@@=');
define('SECURE_AUTH_KEY',  '9JM@!*[7:xbJ{QZ;02m;.={FknaU(13k!xf/YMEA$ptoTs|Mn,e<(@hBA&-dymvg');
define('LOGGED_IN_KEY',    'h2Kc]EhY8Q>KIfZBU(Yw:U2[*N|h>&jNU1-@~6W>oYpe16R(n:A@,u.}#d5R7z;+');
define('NONCE_KEY',        'u^(hXx.QCKJ6-,q[+>Nna,uNV0xU ]aQI,6@n(5M2jvD;JLeW4l0%ifgxvE&KaLC');
define('AUTH_SALT',        'm@:*H~UXKHZp*sgI.8Kp5x_0Jin`Xsa80&XIzG9&3-+eP8ebYJ)z~!Gs0 6ljgG ');
define('SECURE_AUTH_SALT', '/U-(#MN);{M![&mim,Y&(s^lANQjFj&b^@FqHG8%%a;=9Zmc31/C@k@Cj?<9{?+Z');
define('LOGGED_IN_SALT',   '1nK3F,XB??W|VXfS`&Zj^Je4WDe-AJ%}F,Q]hZh<l>t=_(=N_xfJAD}O@K^U(drj');
define('NONCE_SALT',       '`/&gPCkv$CWC=8:8k}1yO]TooQM7uM/R8@fZVIuf<BQ8G&39hxl%U!4SWG,_>oT]');

/**#@-*/

/**
 * WordPress Database Table prefix.
 *
 * You can have multiple installations in one database if you give each a unique
 * prefix. Only numbers, letters, and underscores please!
 */
$table_prefix  = '5stars_';

/**
 * WordPress Localized Language, defaults to English.
 *
 * Change this to localize WordPress. A corresponding MO file for the chosen
 * language must be installed to wp-content/languages. For example, install
 * de_DE.mo to wp-content/languages and set WPLANG to 'de_DE' to enable German
 * language support.
 */
define('WPLANG', '');

/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 */
define('WP_DEBUG', false);

/* That's all, stop editing! Happy blogging. */

/** Absolute path to the WordPress directory. */
if ( !defined('ABSPATH') )
	define('ABSPATH', dirname(__FILE__) . '/');

/** Sets up WordPress vars and included files. */
require_once(ABSPATH . 'wp-settings.php');
