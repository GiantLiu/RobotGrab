var page = require('webpage').create(),
  system = require('system'),address;
if (system.args.length === 1) {
  console.log('Usage: loadspeed.js <some URL>');
  phantom.exit();
}
address = system.args[1];
page.open(address, function(status) {
  if (status == 'success') {
    console.log(page.content);
  }
  phantom.exit();
});