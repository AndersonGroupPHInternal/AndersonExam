(function () {
    'use strict';

    angular
        .module('App')
        .controller('PositionController', PositionController);

    PositionController.$inject = ['$window', 'PositionService'];

    function PositionController($window, PositionService) {
        var vm = this;

        vm.Position;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;


        function GoToUpdatePage(positionId) {
            $window.location.href = '../Position/Update/' + positionId;
        } 

        function Initialise() {
            Read();
        }

        function Read() {
            PositionService.Read()
                .then(function (response) {
                    vm.Position = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Delete(position) {
            PositionService.Delete(position)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

    }
})();