var page = require('webpage').create(),
    system = require('system'), address;
if (system.args.length === 1) {
    console.log('Usage: loadspeed.js <some URL>');
    phantom.exit();
}
address = system.args[1];
page.onConsoleMessage = function (msg, lineNum, sourceId) { };
page.onError = function (msg, trace) { };
page.onNavigationRequested = function (url, type, willNavigate, main) {
    if (url != address && url != "about:blank") {
        console.log(url);
        page.onNavigationRequested = null;
        phantom.exit();
    }
};
page.open(address, function (status) { });