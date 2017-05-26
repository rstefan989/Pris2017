"use strict";
var editProfile;//namespace
(function (editProfile) {
    //public object
    editProfile.viewModel = {}

    //local object
    var viewModel = function (data) {
        var model = ko.mapping.fromJSON(data);

        return model;
    }

    //public function
    editProfile.init = function (data) {
        editProfile.viewModel = viewModel(data);
        ko.applyBindings(editProfile.viewModel);
    }
}(editProfile || (editProfile = {})));