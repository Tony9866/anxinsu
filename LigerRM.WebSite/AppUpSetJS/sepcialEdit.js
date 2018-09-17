$(function () {

    $(document).on("change", "[name='provinceid']", function () {
        $.ajax({
            cache: false,
            async: false,
            type: 'post',
            dataType: 'json',
            data: { "type": "GetListCity", "provinceid": $(this).val() },
            url: "/AppUpSetAshx/ajax.ashx",
            success: function (data) {
                if (data.Code == "0") {
                    var html = " <option value=\"-1\">--请选择市--</option>";
                    $(data.Data).each(function (index, text) {
                        html += "<option value=\"" + text.cityId + "\">" + text.city + "</option>";
                    })
                    $("[name='cityId']").html(html);
                    console.log(data.Data);
                } else {
                    alert(data.Msg);
                }
            }
        });
    })

    //    $(document).on("change", "[name='provinceid']", function () {
    //        //        alert($(this).valonchange="change(this)"
    //        var value = $(this).val();
    //        $.ajax({
    //            type: "post",
    //            dataType: "json",
    //            url: "../LigerRM_BusinessLayer/AppHomeHelper.cs",
    //            data: { provinceid: 'value' },
    //            success: function (data) {
    //                
    //            }
    //        })

    //    })


        $(document).on("change", "[name = 'cityId']", function () {
//        var cId = $(this).val();
//        alert($cId);
        alert($(this).val()
    )})

});







