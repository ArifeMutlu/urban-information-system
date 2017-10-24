var ajaxMethods = {
    post: function (url, parameters, callback) {
        $.post(url, parameters, callback);
    },
    get: function (url, parameters, callback) {
        return $.get(url, parameters, callback);
    },
    load: function (element, url, parameters, callback) {
        $(element).load(url, parameters, callback);
    }
}

var map = {
    GetMapPartial: function (obj) {
        ajaxMethods.load($(".mapDv"), "/Home/GetMap", { data: obj }, function () { });
    },
    GetSidebarPartial: function () {
        ajaxMethods.load($("#sidebar-menu"), "/Home/SideBar", {}, function () { });
    },
    GetFilter: function () {

        ajaxMethods.load($(".dvFilter"), "/Home/GetFilter", {}, function () { });
    },
    GetMapDetail: function(id,name) {
        ajaxMethods.load($("#MapDetailId"), "/Home/GetMapDetail", {id:id,name:name}, function() {});
    },
    GetSmallMap: function () {
        ajaxMethods.load($("#smallmapDv"), "/Home/GetSmallMap", {}, function () { });
    }
}