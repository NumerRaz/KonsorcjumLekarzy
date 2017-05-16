(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.bookingvisit");

    function controller() {
        var vm = this;
        // global_InitData

        var parseInitData = function() {
            vm.initData.data = global_InitData;
            for (var visit = 0; visit < global_InitData.Visits.length; visit++) {
                let elementDate = moment(global_InitData.Visits[visit].StartDate).toDate();

                vm.initData.allVisits.push({
                    startDate: elementDate,
                    doctorId: global_InitData.Visits[visit].DoctorId,
                    patientId: global_InitData.Visits[visit].PatientId,
                    duration: global_InitData.Visits[visit].Duration,
                    confirmation: global_InitData.Visits[visit].Confirmation
                });
            }
        };

        var getConfirmedVisits = function() {
            let confirmedVisits = [];
            confirmedVisits.filter(function(element, index, array) {
                return element.Confirmation === true;
            });
            vm.initData.confirmedVisits = confirmedVisits;
        };

        var getLastVisit = function() {

            let allVisits = vm.initData.data.Visits;

            allVisits.sort(function(a, b) {
                let jsdateB = moment(b.StartDate).toDate();
                let jsdateA = moment(a.StartDate).toDate();
                return new Date(jsdateB) - new Date(jsdateA);
            });

            vm.initData.nestVisit.push({
                startDate: moment(allVisits[0].StartDate).toDate(),
                doctorId: allVisits[0].DoctorId,
                patientId: allVisits[0].PatientId,
                duration: allVisits[0].Duration,
                confirmation: allVisits[0].Confirmation
            });
        }

        vm.$onInit = function () {
            vm.initData = {};
            vm.initData.allVisits = [];
            vm.initData.confirmedVisits = [];
            vm.initData.nestVisit = [];
            parseInitData();
            getLastVisit();
            getConfirmedVisits();
        }
    }

    module.component("bookingvisit",
    {
        templateUrl: "Angular/pages/bookingVisit/bookingvisit.html",
        controllerAs: "vm",
        controller: controller
    });
})(); 