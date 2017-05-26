/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery/jquery.growl.d.ts" />

namespace app {
    export module notifications {
        export function show(notifications) {
            if (notifications != null) $("#growls").empty();
            notifications = tryParse(notifications);
             if(notifications != null){
                 notifications.forEach(function (notif) {
                     addNotification(notif);
                 });
            };
        }

         export function addError (errMsg) {
            var err = { title: 'Error', message: errMsg, delayOnHover: true, duration: 10000 };
            $.growl.error(err);
        }

         export function addWarning (msg) {
            var notification = { title: 'Warning', message: msg, delayOnHover: true, duration: 10000 };
            $.growl.warning(notification);
        }

         export function addInfo (msg) {
            var notification = { title: 'Info', message: msg, delayOnHover: true, duration: 10000 };
            $.growl.notice(notification);
        }

         export function addNotification (notif) {
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

         function tryParse(param) {
             return (typeof param !== 'string') ? param : JSON.parse(param);
         }
    }
}