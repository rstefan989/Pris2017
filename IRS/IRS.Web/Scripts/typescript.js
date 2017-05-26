/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery/jquery.growl.d.ts" />
var app;
(function (app) {
    var notifications;
    (function (notifications_1) {
        function show(notifications) {
            if (notifications != null)
                $("#growls").empty();
            notifications = tryParse(notifications);
            if (notifications != null) {
                notifications.forEach(function (notif) {
                    addNotification(notif);
                });
            }
            ;
        }
        notifications_1.show = show;
        function addError(errMsg) {
            var err = { title: 'Error', message: errMsg, delayOnHover: true, duration: 10000 };
            $.growl.error(err);
        }
        notifications_1.addError = addError;
        function addWarning(msg) {
            var notification = { title: 'Warning', message: msg, delayOnHover: true, duration: 10000 };
            $.growl.warning(notification);
        }
        notifications_1.addWarning = addWarning;
        function addInfo(msg) {
            var notification = { title: 'Info', message: msg, delayOnHover: true, duration: 10000 };
            $.growl.notice(notification);
        }
        notifications_1.addInfo = addInfo;
        function addNotification(notif) {
            switch (notif.type) {
                case -1:
                    addError(notif.message);
                    break;
                case 1:
                case 2:
                    addInfo(notif.message);
                    break;
                case 3:
                    addWarning(notif.message);
                    break;
                default:
                    addError("Unknown notification type");
            }
        }
        notifications_1.addNotification = addNotification;
        function tryParse(param) {
            return (typeof param !== 'string') ? param : JSON.parse(param);
        }
    })(notifications = app.notifications || (app.notifications = {}));
})(app || (app = {}));
/// <reference path="../typings/jquery/jquery.d.ts" />
