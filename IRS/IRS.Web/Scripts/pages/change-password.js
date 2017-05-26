"use strict";
var changePassword;//namespace
(function (changePassword) {
    //public object
    changePassword.viewModel = {}

    //local object
    var viewModel = function data(data) {
        var model = ko.mapping.fromJSON(data);
        model.oldPassword = ko.observable();
        model.newPassword = ko.observable();
        model.confirmPassword = ko.observable();

        return model;
    }

    //public function
    changePassword.init = function (data) {
        changePassword.viewModel = viewModel(data);
        ko.applyBindings(changePassword.viewModel);
    }
}(changePassword || (changePassword = {})));