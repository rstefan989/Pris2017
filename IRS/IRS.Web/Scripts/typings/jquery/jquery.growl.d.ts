/// <reference path="jquery.d.ts" />

interface JQueryStatic {
    growl: JQueryGrowlStatic;
}

interface JQueryGrowlStatic {
    error(notification: any);
    warning(notification: any);
    notice(notification: any);
}
