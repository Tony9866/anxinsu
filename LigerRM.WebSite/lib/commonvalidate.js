//validate ID card
function getIdCardInfo(cardNo) {
    var info = {
        isTrue: false, // 身份证号是否有效。默认为 false
        year: null, // 出生年。默认为null
        month: null, // 出生月。默认为null
        day: null, // 出生日。默认为null
        isMale: false, // 是否为男性。默认false
        isFemale: false // 是否为女性。默认false
    };

//    if (!cardNo && 15 != cardNo.length && 18 != cardNo.length) {
//        info.isTrue = false;
//        return info;
//    }

    if (15 == cardNo.length) {
        var year = cardNo.substring(6, 8);
        var month = cardNo.substring(8, 10);
        var day = cardNo.substring(10, 12);
        var p = cardNo.substring(14, 15); // 性别位
        var birthday = new Date(year, parseFloat(month) - 1, parseFloat(day));
        // 对于老身份证中的年龄则不需考虑千年虫问题而使用getYear()方法
        if (birthday.getYear() != parseFloat(year)
				|| birthday.getMonth() != parseFloat(month) - 1
				|| birthday.getDate() != parseFloat(day)) {
            info.isTrue = false;
        } else {
            info.isTrue = true;
            info.year = birthday.getFullYear();
            info.month = birthday.getMonth() + 1;
            info.day = birthday.getDate();
            if (p % 2 == 0) {
                info.isFemale = true;
                info.isMale = false;
            } else {
                info.isFemale = false;
                info.isMale = true;
            }
        }
        return info;
    }

    if (18 == cardNo.length) {
        var year = cardNo.substring(6, 10);
        var month = cardNo.substring(10, 12);
        var day = cardNo.substring(12, 14);
        var p = cardNo.substring(14, 17);
        var birthday = new Date(year, parseFloat(month) - 1, parseFloat(day));
        // 这里用getFullYear()获取年份，避免千年虫问题
        if (birthday.getFullYear() != parseFloat(year)
				|| birthday.getMonth() != parseFloat(month) - 1
				|| birthday.getDate() != parseFloat(day)) {
            info.isTrue = false;
            return info;
        }

        var Wi = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1]; // 加权因子
        var Y = [1, 0, 10, 9, 8, 7, 6, 5, 4, 3, 2]; // 身份证验证位值.10代表X

        // 验证校验位
        var sum = 0; // 声明加权求和变量
        var _cardNo = cardNo.split("");

        if (_cardNo[17].toLowerCase() == 'x') {
            _cardNo[17] = 10; // 将最后位为x的验证码替换为10方便后续操作
        }
        for (var i = 0; i < 17; i++) {
            sum += Wi[i] * _cardNo[i]; // 加权求和
        }
        var i = sum % 11; // 得到验证码所位置

        if (_cardNo[17] != Y[i]) {
            return info.isTrue = false;
        }

        info.isTrue = true;
        info.year = birthday.getFullYear();
        info.month = birthday.getMonth() + 1;
        info.day = birthday.getDate();

        if (p % 2 == 0) {
            info.isFemale = true;
            info.isMale = false;
        } else {
            info.isFemale = false;
            info.isMale = true;
        }
        return info;
    }
    return info;
}

///validate the phone number
function isTelOrMobile(telephone) {
    var regExp = /^\d+(\.\d+)?$/;
    var teleReg = /^\d{7,8}$/;
    var mobileReg = /^1[3578]\d{9}$/;
    if (!teleReg.test(telephone) && !mobileReg.test(telephone)) {
        return false;
    } else {
        return true;
    }
}

Date.prototype.toFomatorString = function (formator) {
    var returnText = formator.toUpperCase();

    if (returnText.indexOf("YYYY") > -1) {
        returnText = returnText.replace("YYYY", this.getFullYear());
    }

    if (returnText.indexOf("MM") > -1) {
        returnText = returnText.replace("MM", this.getMonth() + 1);
    }

    if (returnText.indexOf("DD") > -1) {
        returnText = returnText.replace("DD", this.getDate());
    }

    if (returnText.indexOf("HH") > -1) {
        returnText = returnText.replace("HH", this.getHours());
    }

    if (returnText.indexOf("MI") > -1) {
        returnText = returnText.replace("MI", this.getMinutes());
    }

    if (returnText.indexOf("SS") > -1) {
        returnText = returnText.replace("SS", this.getSeconds());
    }

    if (returnText.indexOf("SI") > -1) {
        returnText = returnText.replace("SI", this.getMilliseconds());
    }

    return returnText;
}

