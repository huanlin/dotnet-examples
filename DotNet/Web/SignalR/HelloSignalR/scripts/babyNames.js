/// <reference path="jquery-3.1.1.js" />
/// <reference path="jquery.signalR-2.2.1.js" />


$(document).ready(function () {
    var hub = $.connection.babyNamesHub;
    var babyNamesTable = $('#BabyNamesTable');
    var babyName = $('#BabyNameTextBox');

    hub.client.babyNamed = function (name) {
        babyNamesTable.append("<tr><td>" + name + "</td></tr>");
        babyName.val("");
    };

    $.connection.hub.start().done(function () {
        $("#AddBabyNameButton").click(function () {
            var name = babyName.val();

            // 呼叫 server 端的 BabyNamesHub 類別的 AddBabyName 方法。
            // 注意這裡的 add* 是小寫。若改成 Add*，執行時會發生 javascript 錯誤：hub.server.AddBabyName is not a function。
            hub.server.addBabyName(name); 
        });
    });
});