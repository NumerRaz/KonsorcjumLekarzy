(function() {
    "use strict";

    const module = angular.module("BlurAdmin.pages.doctors");

    controller.$inject = ["$http", "dataServices"];

    function controller($http, dataServices) {
        var vm = this;

        var setAvaliableHours = function() {
            for (let i = 8; i <= 16; i++) {
                vm.initData.avaliableHours.push(i + ":00");
            }
        };

        var parseInitData = function() {
            vm.initData.data = global_InitData.Doctors;
            vm.userRole = global_InitData.User[0].RoleName;
            for (let doctor = 0; doctor < vm.initData.data.length; doctor++) {
                vm.initData.doctorsList.push(vm.initData.data[doctor]);
                console.log(`Add: ${vm.initData.data[doctor].FirstName}`);
            }
        };

        var getSelectedDoctor = function() {
            if (vm.initData.selectedDoctor === "" || vm.initData.selectedDoctor === undefined) {
                vm.initData.selectedDoctor = "No doctor has yet been selected";
            }
        };

        var getInitData = function() {
            $http.get("/home/GetInitialData")
                .success(function(data, status, header, config) {
                    console.log(`Init data status: ${status}`);
                })
                .error(function(data, status, header, config) {
                    console.log(`Init data error: ${status}`);
                });
        };

        vm.selectDoctors = function(item) {
            vm.initData.selectedDoctor.label = item.label;
            vm.initData.selectedDoctor.value = item.value;
        };

        vm.getActiveDoctor = function() {
            let active = {};
            active = vm.initData.doctorsList.filter(function(element, index, array) {
                return element.DoctorId === vm.initData.selectedDoctor.value;
            });
            return active;
        };

        vm.bookingVisit = function() {
            if (vm.initData.selectedDoctor.label !== "" &&
                vm.initData.selectedDoctor.label !== undefined &&
                vm.initData.selectedDoctor.label !== null) {
                vm.displayErrorMessages = false;
                vm.selectedDoctorState = true;
                vm.actionType = "bookingVisit";
            } else {
                vm.displayErrorMessages = true;
            }
        };

        vm.sendMessage = function() {
            if (vm.initData.selectedDoctor.label !== "" &&
                vm.initData.selectedDoctor.label !== undefined &&
                vm.initData.selectedDoctor.label !== null) {
                vm.actionType = "sendEmail";
                vm.displayErrorMessages = false;
            } else {
                vm.displayErrorMessages = true;
            }

        };

        vm.saveVisit = function(item) {
            const actualHour = item.target.innerText;
            const actualDay = vm.dt;
            const actualSelectedDoctor = vm.initData.selectedDoctor;
            const actualUser = global_InitData.User;

            if (actualHour !== "" && actualDay !== "" && actualSelectedDoctor.label !== "" && actualUser.UserName !== ""
            ) {
                $http({
                        url: "/home/BookingVisit",
                        method: "POST",
                        data: {
                            'hour': actualHour,
                            'day': actualDay,
                            'doctor': actualSelectedDoctor.value,
                            'patient': actualUser[0].id
                        }
                    })
                    .then(function(response) {
                        console.log(response);
                        },
                        function(response) { 
                            // failed
                        });
            }
        };

        vm.$onInit = function() {
            vm.initData = {};
            vm.initData.data = {};
            vm.initData.doctorsList = [];
            vm.initData.selectedDoctor = {};
            vm.initData.avaliableHours = [];
            vm.displayErrorMessages = false;
            vm.dt = "";
            vm.selectedDoctorState = false;
            vm.selectedHours = "";
            vm.errorMessagesAvaliableActions = "You need to select a doctor to perform the action.";
            vm.actionType = "";
            vm.userRole = "";
            parseInitData();
            getInitData();
            getSelectedDoctor();
            setAvaliableHours();
        };
    }

    module.component("doctors",
    {
        templateUrl: "Angular/pages/doctors/doctors.html",
        controllerAs: "vm",
        controller: controller
    });

})();