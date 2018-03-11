var app = angular.module('myLibrary', []);
app.controller('myAuthorCtrl', function ($scope, $http) {
  
    $scope.GetAllAuthors = function () {
        $http.get("/Api/GetAllAuthors")
            .then(function (response) {
                $scope.authors = response.data;
            });
    }

    $scope.clickAddAuthor = function (newAuthor) {
        $http.post("/Api/AddAuthor", newAuthor)
            .then(function (response) {
                $scope.GetAllAuthors();
            });
    }

    $scope.GetAllAuthors();
});