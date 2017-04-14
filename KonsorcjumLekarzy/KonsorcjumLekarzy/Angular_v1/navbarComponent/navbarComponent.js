(function() {

    var navbarComponentCntr = function() {
        var vm = this;

        var checkAccountType = function() {
            switch (vm.doctor.type) {
                case "admin":
                    vm.singlePanelList = vm.accountType.find(x => x.type === "admin").singlePanel;
                    break;
                case "doctor":
                    vm.singlePanelList = vm.accountType.find(x => x.type === "doctor").singlePanel;
                    break;
            default:
            }
        };

        vm.$onInit = function () {
            vm.singlePanelList = [];
            vm.accountType = [
                {
                    type: "admin",
                    singlePanel: [
                        "Profile",
                        "Doctors",
                        "Patient"
                    ]
                },
                {
                    type: "doctor",
                    singlePanel: [
                        "Profile",
                        "Grafik",
                        "Wiadomosci",
                        "Kontakt"
                    ]
                }
            ];
            checkAccountType();
        };
    };

    angular.module("app")
        .component("navbarComponent",
        {
            templateUrl: "../Angular/navbarComponent/navbarComponent.html",
            controllerAs: "vm",
            bindings: {
                doctor: "<"
            },
            controller: navbarComponentCntr
        });

})();