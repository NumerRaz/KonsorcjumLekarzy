(function() {

    var appComponentCntr = function() {
        var vm = this;
        vm.doctor = {
            type: "doctor",
            name: "Janusz"
        };
    };

    angular.module("app")
        .component("appComponent",
        {
            templateUrl: "../Angular/appComponent/appComponent.html",
            bindings: {
                doctors: "<"
            },
            controllerAs: "vm",
            controller: appComponentCntr
        });

})();