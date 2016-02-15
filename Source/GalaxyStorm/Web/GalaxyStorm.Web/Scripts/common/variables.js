/*==============================================================================
1000 = one second
==============================================================================*/

/*==============================================================================
color
==============================================================================*/
var _mainColor = 'dark'; // ['light', 'dark']

/* light overlay */
var _lightOverlayColor = 'rgba(255, 255, 255, 0.4)'; // [rgba format] - overlay color
var _lightFormOverlayColor = 'rgba(62, 68, 89, 0.8)'; // [rgba format] - form overlay color

/* dark overlay */
var _darkOverlayColor = 'rgba(62, 68, 89, 0.3)'; //originally 0.6 alpha [rgba format] - overlay color
var _darkFormOverlayColor = 'rgba(62, 68, 89, 0.8)'; // [rgba format] - form overlay color

/*==============================================================================
site loader
==============================================================================*/
var _siteLoaderDuration = 750; // duration
var _siteLoaderDelay = 500; // delay

/*==============================================================================
border - border force disable on mobile
==============================================================================*/
var _border = false; // [true, false] - border

/*==============================================================================
text animation
==============================================================================*/
var _animationDuration = 1750; // animation duration

/*==============================================================================
countdown
==============================================================================*/
var _countdown = false; // countdown toggle
var _countdownDate = '12/24/2015 23:59:59'; // 2015-12-24 23:59:59
var _countdownTimezone = '-8'; // timezone

/*=================================================
background style
=================================================*/
var _bgStyle = 1; // 1 = image, 2 = slideshow, 3 = html5 video, 4 = youtube video

/*=================================================
_bgStyle = 1
  - replace background image at assets/img/bg/bg.jpg
=================================================*/

/*=================================================
_bgStyle = 2
  - slideshow
=================================================*/
var _imgAmount = 4; // min = 2, how many image at slideshow, file name slideshow-01.jpg, slideshow-02.jpg...slideshow-10.jpg etc
var _kenburn = 1; // 1 = kenburn effect slideshow, 2 = normal slideshow

/*=================================================
_bgStyle = 3
 - html5 video
=================================================*/
var _videoMute = true; // mute on start
var _removeVolume = false; // remove volume icon, if _videoMute = false will still have volume

/*=================================================
_bgStyle = 4
  - youtube video
=================================================*/
var _ytUrl = 'wr-srbfQeKk'; // youtube video id
var _ytQuality = 'hightres'; // hightres, hd1080, hd720, default - youtube video quality
var _ytStart = 35; // start time (seconds)
var _ytEnd = 120; // end time (seconds), 0 to ignored
var _ytLoop = true; // loop
var _ytMute = false; // mute on start
var _ytRemoveVolume = false; // remove volume icon, if _ytMute = false will still have volume

/*==============================================================================
audio - only work when bg style not video or youtube video
==============================================================================*/
var _audio = false; // enable audio on desktop devices

/*=================================================
effect
=================================================*/
var _effect = 0; // 0 = disable, 1 = cloud, 2 = star

/*=================================================
_effect = 2
  - star
=================================================*/
var _starColor = 'rgba(255, 255, 255, 0.9)';// star color
var _starWidth = 1.5;// star width