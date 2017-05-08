'use strict';

app.controller('LoginController', function ($scope) {

    $scope.login = function () {
        manager.signinPopup()
        .catch(function (error) {
            console.error('error while logging in through the popup', error);
        });
    }

    function display(selector, data) {
        if (data && typeof data === 'string') {
            data = JSON.parse(data);
        }
        if (data) {
            data = JSON.stringify(data, null, 2);
        }

        $(selector).text(data);
    }

    var settings = {
        authority: 'https://localhost:44300/',
        client_id: 'js',
        popup_redirect_uri: 'http://localhost:56668/View/popup.html',
        silent_redirect_uri: 'http://localhost:56668/View/silent-renew.html',
        post_logout_redirect_uri: 'http://localhost:56668/index.html',

        response_type: 'id_token',
        scope: 'openid profile email',

        filterProtocolClaims: true
    };

    var manager = new Oidc.UserManager(settings);
    var user;

    manager.events.addUserLoaded(function (loadedUser) {
        user = loadedUser;
        display('.js-user', user);
    });

});