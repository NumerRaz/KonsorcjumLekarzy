(function() {
    "use strict";

    const module = angular.module("BlurAdmin.pages.bookingvisit");

    function controller() {
        var vm = this;
        // global_InitData

        var parseInitData = function() {
            vm.initData.data = global_InitData;
            for (let visit = 0; visit < global_InitData.Visits.length; visit++) {
                const elementDate = moment(global_InitData.Visits[visit].StartDate).toDate();

                vm.initData.allVisits.push({
                    visitId: global_InitData.Visits[visit].VisitID,
                    startDate: elementDate,
                    doctorId: getUserById("doctor",global_InitData.Visits[visit].DoctorId),
                    patientId: getUserById("patient",global_InitData.Visits[visit].PatientId),
                    duration: global_InitData.Visits[visit].Duration,
                    confirmation: global_InitData.Visits[visit].Confirmation
                });
            }
        };

        var getUserById = function(userType, id) {
            let searchUser = {};
            if (userType === "doctor") {
                searchUser = global_InitData.Doctors.filter(function(element) {
                    return element.DoctorId === id;
                });
            } else if (userType === "patient") {
                searchUser = global_InitData.Patients.filter(function(element) {
                    return element.PatientId === id;
                });
                return searchUser[0].FirstName + " " + searchUser[0].LastName;
            };
        };

        var getConfirmedVisits = function() {
            let confirmedVisits = [];
            confirmedVisits = vm.initData.data.Visits.filter(function(element, index, array) {
                return element.Confirmation === true;
            });
            for (let visit = 0; visit < confirmedVisits.length; visit++) {
                const elementDate = moment(confirmedVisits[visit].StartDate).toDate();

                vm.initData.confirmedVisits.push({
                    visitId: global_InitData.Visits[visit].VisitID,
                    startDate: elementDate,
                    doctorId: confirmedVisits[visit].DoctorId,
                    patientId: confirmedVisits[visit].PatientId,
                    duration: confirmedVisits[visit].Duration,
                    confirmation: confirmedVisits[visit].Confirmation
                });
            }
        };

        var getLastVisit = function() {

            const allVisits = vm.initData.data.Visits;

            allVisits.sort(function(a, b) {
                const jsdateB = moment(b.StartDate).toDate();
                const jsdateA = moment(a.StartDate).toDate();
                return new Date(jsdateB) - new Date(jsdateA);
            });

            vm.initData.nestVisit.push({
                visitId: allVisits[0].VisitID,
                startDate: moment(allVisits[0].StartDate).toDate(),
                doctorId: allVisits[0].DoctorId,
                patientId: allVisits[0].PatientId,
                duration: allVisits[0].Duration,
                confirmation: allVisits[0].Confirmation
            });
        };
        vm.$onInit = function() {
            vm.initData = {};
            vm.initData.allVisits = [];
            vm.initData.confirmedVisits = [];
            vm.initData.nestVisit = [];
            parseInitData();
            getLastVisit();
            getConfirmedVisits();
        };
    }

    module.component("bookingvisit",
    {
        templateUrl: "Angular/pages/bookingVisit/bookingvisit.html",
        controllerAs: "vm",
        controller: controller
    });
})();