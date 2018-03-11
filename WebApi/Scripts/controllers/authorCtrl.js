var app = angular.module('myAuthor', []);
app.controller('myAuthorCtrl', function ($scope, $http) {
  
    $scope.GetAllAuthors = function () {
        $http.get("/Api/GetAllAuthors")
            .then(function (response) {
                $scope.authors = response.data;
            });
    }

    $scope.GetAllAuthors();
});