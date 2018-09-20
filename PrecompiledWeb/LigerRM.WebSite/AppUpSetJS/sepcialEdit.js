$(function () {
//获取省id然后传给市
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

//获取sortId
    $(document).on("change", "[name = 'cityId']", function () {
        ////        var cId = $(this).val();
        ////        alert($cId);
        //        alert($(this).val()
        $.ajax({
            cache: false,
            async: false,
            type: 'post',
            dataType: 'json',
            data: { "type": "getSortId", "cityId": $(this).val() },
            url: "/AppUpSetAshx/ajax.ashx",
            success: function (data) {
            var html = " <option value=\"-1\">--当前排序--</option>";
                if (data.Code == "0") {                    
                    console.log(data.Data);
                    $(data.Data).each(function (index, text) {
                        html += "<option value=\"" + text.cityId + "\">" + text.sortId + "</option>";
                    })
                    $("[name='sortId']").html(html);
                    console.log(data.Data);
                }
//                if(data.Code == "0" && list != null)
//                {
//                     console.log(data.Data);
//                    $(data.Data).each(function (index, text) {

//                        html += "<option value=\"" + text.cityId + "\">" + (parseInt(text.sortId)+1) + "</option>";
//                    })
//                    $("[name='sortId']").html(html);
//                    console.log(data.Data);
//                }       
                else {
                    alert(data.Msg);
                }
            }
        });
    })

//    div();

//    $(document).on("click", "#button", function () {

//        div();
//    })

});

//这是排序ajax
//function div() {
//    $.ajax({
//        cache: false,
//        async: false,
//        type: 'post',
//        dataType: 'json',
//        data: { "type": "getSortId", "cityId": "120100" },
//        url: "/AppUpSetAshx/ajax.ashx",
//        success: function (data) {
//            if (data.Code == "0") {
//                var html = "";
//                $(data.Data).each(function (index, text) {
//                    html += "<a href='#' name=\"a_" + text.cityId + "\">" + text.Name + "</a><br/>";
//                })
//                $("[name='cityId']").html(html);
//                console.log(data.Data);
//            } else {
//                alert(data.Msg);
//            }

//            $("[name='div']").html(html);
//        }
//    });

   
//}







