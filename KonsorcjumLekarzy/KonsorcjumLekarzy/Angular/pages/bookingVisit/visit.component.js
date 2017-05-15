(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.bookingvisit");

    function controller() {
        var vm = this;
        // global_InitData

        var parseInitData = function() {
            vm.initData.data = global_InitData;
            for (var visit = 0; visit < global_InitData.Visits.length; visit++) {
                vm.initData.allVisits.push({
                    startDate: global_InitData.Visits[visit].StartDate,
                    doctorId: global_InitData.Visits[visit].DoctorId,
                    patientId: global_InitData.Visits[visit].PatientId,
                    duration: global_InitData.Visits[visit].Duration,
                    confirmation: global_InitData.Visits[visit].Confirmation
                });
            }
        };


        vm.$onInit = function () {
            vm.initData = {};
            vm.initData.allVisits = [];
            vm.initData.confirmedVisits = [];
            vm.initData.nestVisit = [];
            parseInitData();
        }
    }

    module.component("bookingvisit",
    {
        templateUrl: "Angular/pages/bookingVisit/bookingvisit.html",
        controllerAs: "vm",
        controller: controller
    });
})(); 