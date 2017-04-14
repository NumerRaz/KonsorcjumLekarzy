(function() {

    var singlePanelComponentCntr = function() {
        var vm = this;

        vm.$onInit = function() {
        };
    };

    angular.module("app")
        .component("singlePanelComponent",
        {
            templateUrl: "../Angular/singlePanelComponent/singlePanelComponent.html",
            bindings: {
                panelname: "<"
            },
            controllerAs: "vm",
            controller: singlePanelComponentCntr
});

})();