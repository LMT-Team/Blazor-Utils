//LMT Blazor Utils 0.1 bundled
//If a jQuery method has both get and set function, add number 2 after function name of the "get" one

$(() => {
    $("head").append('<link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet"/>');
    $("head").append('<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet"/>');
    $.getScript('https://code.jquery.com/ui/1.12.1/jquery-ui.min.js');
    $.getScript('https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.bundle.min.js');
    LMTDomBoot();
    LMTCookieBoot();
});

function LMTCookieBoot() {
    //Reference to https://www.w3schools.com/js/js_cookies.asp
    let setCookie = (cname, cvalue, exdays, path) => {
        var expires = "";
        if (exdays != 0) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            expires = ";expires=" + d.toUTCString();
        }
        document.cookie = cname + "=" + cvalue + expires + ";path=" + path;
    }

    Blazor.registerFunction('LMTCookies',
        function () {
            return document.cookie;
        });

    Blazor.registerFunction('LMTCookiesAdd',
        function (key, value, exp, path) {
            setCookie(key, value, exp, path);
        });
}

function LMTDomBoot() {
    //Behaviors
    Blazor.registerFunction('LMTBehavioursBoot',
        function () {
            let s4 = () => {
                return Math.floor((1 + Math.random()) * 0x10000)
                    .toString(16)
                    .substring(1);
            }

            let guid = () => {
                //No symbol guid, reference: https://stackoverflow.com/questions/105034/create-guid-uuid-in-javascript
                return s4() + s4() + "-" + s4() + "-" + s4() + "-" + s4() + "-" + s4() + s4() + s4();
            }

            //Reference to https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/random
            let randomIntInclusive = (min, max) => {
                if (min > max)
                    return NaN;

                min = Math.ceil(min);
                max = Math.floor(max);
                return Math.floor(Math.random() * (max - min + 1)) +
                    min; //The maximum is inclusive and the minimum is inclusive
            }

            //lmt-draggable
            $("[lmt-drag]").draggable();
            //lmt-resize
            $("[lmt-resize]").resizable();
            //lmt-select
            $("[lmt-select]").selectable();
            //lmt-sort
            $("[lmt-sort]").sortable();
            //lmt-readonly
            $.each($("[lmt-readonly]"),
                (ind, val) => {
                    $(val).prop("readonly", true).prop("title", val.getAttributeNode("lmt-readonly").value).tooltip();
                });
            //lmt-val-guid
            $("[lmt-val-guid]").val(() => {
                return guid();
            });
            //lmt-val-num
            $.each($("[lmt-val-num]"),
                (ind, ele) => {
                    let params = ele.getAttributeNode("lmt-val-num").value.split(",");
                    ele.value = randomIntInclusive(parseInt(params[0]), parseInt(params[1]));
                });
            //lmt-accord
            $("[lmt-accord]").accordion();
            //lmt-autocomp
            $.each($("[lmt-autocomp]"),
                (ind, ele) => {
                    $(ele).autocomplete({
                        source: ele.getAttributeNode("lmt-autocomp").value.split(",")
                    });
                });
            //lmt-date
            $("[lmt-date]").datepicker();
            //lmt-dialog
            $("[lmt-dialog]").dialog();
            //lmt-tip
            $.each($("[lmt-tip]"),
                (ind, val) => {
                    $(val).prop("title", val.getAttributeNode("lmt-tip").value).tooltip();
                });
        });

    //Reference to https://learn-blazor.com/architecture/interop/
    // ReSharper disable once InconsistentNaming
    function BlazorUtilsCallCSUICallBack(id) {
        const assemblyName = 'BlazorUtils.Dom';
        const namespace = 'BlazorUtils.Dom.Storages';
        const typeName = 'UICallBacksStorage';
        const methodName = 'Invoke';

        const method = Blazor.platform.findMethod(
            assemblyName,
            namespace,
            typeName,
            methodName
        );

        let csid = Blazor.platform.toDotNetString(id);

        Blazor.platform.callMethod(method, null, [csid]);
    }

    // ReSharper disable once InconsistentNaming
    function BlazorUtilsCallIntStringString(id, ind, className) {
        const assemblyName = 'BlazorUtils.Dom';
        const namespace = 'BlazorUtils.Dom.Storages';
        const typeName = 'IntStringStringStorage';
        const methodName = 'Invoke';

        const method = Blazor.platform.findMethod(
            assemblyName,
            namespace,
            typeName,
            methodName
        );

        let csid = Blazor.platform.toDotNetString(id);
        let csind = Blazor.platform.toDotNetString(ind);
        let csclassName = Blazor.platform.toDotNetString(className);

        let res = Blazor.platform.callMethod(method, null, [csid, csind, csclassName]);

        return Blazor.platform.toJavaScriptString(res);
    }

    // ReSharper disable once InconsistentNaming
    function BlazorUtilsCallIntInt(id, ind, value, typeOfRet) {
        const assemblyName = 'BlazorUtils.Dom';
        const namespace = 'BlazorUtils.Dom.Storages';
        let typeName;
        if (typeOfRet === "string")
            typeName = 'IntIntStringStorage';
        else
            typeName = 'IntIntDoubleStorage';
        const methodName = 'Invoke';

        const method = Blazor.platform.findMethod(
            assemblyName,
            namespace,
            typeName,
            methodName
        );

        let csid = Blazor.platform.toDotNetString(id);
        let csind = Blazor.platform.toDotNetString(ind);
        let csvalue = Blazor.platform.toDotNetString(value);

        let res = Blazor.platform.callMethod(method, null, [csid, csind, csvalue]);

        return Blazor.platform.toJavaScriptString(res);
    }

    // ReSharper disable once InconsistentNaming
    function BlazorUtilsCallIntDouble(id, ind, value, typeOfRet) {
        const assemblyName = 'BlazorUtils.Dom';
        const namespace = 'BlazorUtils.Dom.Storages';
        let typeName;
        if (typeOfRet === "string")
            typeName = 'IntDoubleStringStorage';
        else
            typeName = 'IntDoubleDoubleStorage';
        const methodName = 'Invoke';

        const method = Blazor.platform.findMethod(
            assemblyName,
            namespace,
            typeName,
            methodName
        );

        let csid = Blazor.platform.toDotNetString(id);
        let csind = Blazor.platform.toDotNetString(ind);
        let csvalue = Blazor.platform.toDotNetString(value);

        let res = Blazor.platform.callMethod(method, null, [csid, csind, csvalue]);

        return Blazor.platform.toJavaScriptString(res);
    }

    // ReSharper disable once InconsistentNaming
    function BlazorUtilsCallIntCoordsCoords(id, ind, value1, value2) {
        const assemblyName = 'BlazorUtils.Dom';
        const namespace = 'BlazorUtils.Dom.Storages';
        const typeName = "IntCoordsCoordsStorage";
        const methodName = 'Invoke';

        const method = Blazor.platform.findMethod(
            assemblyName,
            namespace,
            typeName,
            methodName
        );

        let csid = Blazor.platform.toDotNetString(id);
        let csind = Blazor.platform.toDotNetString(ind);
        let csvalue1 = Blazor.platform.toDotNetString(value1);
        let csvalue2 = Blazor.platform.toDotNetString(value2);

        let res = Blazor.platform.callMethod(method, null, [csid, csind, csvalue1, csvalue2]);
        console.log(Blazor.platform.toJavaScriptString(res));
        return JSON.parse(Blazor.platform.toJavaScriptString(res));
    }

    //Pure Js
    Blazor.registerFunction('LMTDomEval', function (jsCode) {
        eval(jsCode);
    });

    //jQuery

    Blazor.registerFunction('LMTDomToggle', function (selector) {
        $(selector).toggle(selector);
    });

    Blazor.registerFunction('LMTDomAttr', function (selector, attribute, value) {
        $(selector).attr(attribute, value);
    });

    Blazor.registerFunction('LMTDomAttr2', function (selector, attribute) {
        return $(selector).attr(attribute);
    });

    Blazor.registerFunction('LMTDomVal', function (selector, value) {
        $(selector).val(value);
    });

    Blazor.registerFunction('LMTDomVal2', function (selector) {
        return $(selector).val();
    });

    Blazor.registerFunction('LMTDomText', function (selector, text) {
        $(selector).text(text);
    });

    Blazor.registerFunction('LMTDomText2', function (selector) {
        return $(selector).text();
    });

    Blazor.registerFunction('LMTDomCss', function (selector, propertyName, value) {
        $(selector).css(propertyName, value);
    });

    Blazor.registerFunction('LMTDomCss2', function (selector, propertyName) {
        return $(selector).css(propertyName);
    });

    Blazor.registerFunction('LMTAnimate', function (selector, properties, duration, easing) {
        $(selector).animate(properties, duration, easing);
    });

    Blazor.registerFunction('LMTAnimateOptions', function (selector, properties, options) {
        $(selector).animate(properties, options);
    });

    Blazor.registerFunction('LMTOn', function (selector, events, handler) {
        $(selector).on(events, () => {
            BlazorUtilsCallCSUICallBack(handler);
        });
    });

    Blazor.registerFunction('LMTAdd', function (selector, arg) {
        $(selector).add(arg);
    });

    Blazor.registerFunction('LMTAddClass', function (selector, className) {
        $(selector).addClass(className);
    });

    Blazor.registerFunction('LMTHasClass', function (selector, className) {
        return $(selector).hasClass(className);
    });

    Blazor.registerFunction('LMTHtml', function (selector) {
        return $(selector).html();
    });

    Blazor.registerFunction('LMTProp', function (selector, propertyName) {
        return $(selector).prop(propertyName);
    });

    Blazor.registerFunction('LMTRemoveAttr', function (selector, attributeName) {
        return $(selector).removeAttr(attributeName);
    });

    Blazor.registerFunction('LMTRemoveClass', function (selector, className) {
        $(selector).removeClass(className);
    });

    Blazor.registerFunction('LMTRemoveClassFunc', function (selector, id) {
        $(selector).removeClass((ind, className) => {
            return BlazorUtilsCallIntStringString(id, ind + "", className);
        });
    });

    Blazor.registerFunction('LMTRemoveProp', function (selector, propertyName) {
        $(selector).removeProp(propertyName);
    });

    Blazor.registerFunction('LMTToggleClass1', function (selector, className) {
        $(selector).toggleClass(className);
    });

    Blazor.registerFunction('LMTToggleClass2', function (selector, className, state) {
        $(selector).toggleClass(className, state);
    });

    Blazor.registerFunction('LMTToggleClass3', function (selector, id) {
        $(selector).toggleClass((ind, className) => {
            return BlazorUtilsCallIntStringString(id, ind + "", className);
        });
    });

    Blazor.registerFunction('LMTToggleClass4', function (selector, id, state) {
        $(selector).toggleClass((ind, className) => {
            return BlazorUtilsCallIntStringString(id, ind + "", className);
        }, state);
    });

    Blazor.registerFunction('LMTHeight2', function (selector) {
        return $(selector).height();
    });

    Blazor.registerFunction('LMTHeight', function (selector, value) {
        $(selector).height(value);
    });

    Blazor.registerFunction('LMTHeightFunc1', function (selector, id) {
        $(selector).height((ind, height) => {
            return BlazorUtilsCallIntInt(id, ind + "", height + "", "number");
        });
    });

    Blazor.registerFunction('LMTHeightFunc2', function (selector, id) {
        $(selector).height((ind, height) => {
            return BlazorUtilsCallIntInt(id, ind + "", height + "", "string");
        });
    });

    Blazor.registerFunction('LMTInnerHeight2', function (selector) {
        return $(selector).innerHeight();
    });

    Blazor.registerFunction('LMTInnerHeight', function (selector, value) {
        $(selector).innerHeight(value);
    });

    Blazor.registerFunction('LMTInnerHeightFunc1', function (selector, id) {
        $(selector).innerHeight((ind, height) => {
            return BlazorUtilsCallIntDouble(id, ind + "", height + "", "string");
        });
    });

    Blazor.registerFunction('LMTInnerHeightFunc2', function (selector, id) {
        $(selector).innerHeight((ind, height) => {
            return BlazorUtilsCallIntDouble(id, ind + "", height + "", "number");
        });
    });

    Blazor.registerFunction('LMTWidth2', function (selector) {
        return $(selector).width();
    });

    Blazor.registerFunction('LMTWidth', function (selector, value) {
        $(selector).width(value);
    });

    Blazor.registerFunction('LMTWidthFunc1', function (selector, id) {
        $(selector).width((ind, value) => {
            return BlazorUtilsCallIntInt(id, ind + "", value + "", "string");
        });
    });

    Blazor.registerFunction('LMTWidthFunc2', function (selector, id) {
        $(selector).width((ind, value) => {
            return BlazorUtilsCallIntInt(id, ind + "", value + "", "number");
        });
    });

    Blazor.registerFunction('LMTInnerWidth2', function (selector) {
        return $(selector).innerWidth();
    });

    Blazor.registerFunction('LMTInnerWidth', function (selector, value) {
        $(selector).innerWidth(value);
    });

    Blazor.registerFunction('LMTInnerWidthFunc1', function (selector, id) {
        $(selector).innerWidth((ind, width) => {
            return BlazorUtilsCallIntDouble(id, ind + "", width + "", "string");
        });
    });

    Blazor.registerFunction('LMTInnerWidthFunc2', function (selector, id) {
        $(selector).innerWidth((ind, width) => {
            return BlazorUtilsCallIntDouble(id, ind + "", width + "", "number");
        });
    });

    Blazor.registerFunction('LMTOffset2', function (selector) {
        return $(selector).offset();
    });

    Blazor.registerFunction('LMTOffset', function (selector, coordinates) {
        $(selector).offset(coordinates);
    });

    Blazor.registerFunction('LMTOffsetFunc', function (selector, id) {
        $(selector).offset((ind, coords) => {
            return BlazorUtilsCallIntCoordsCoords(id, ind + "", coords.top + "", coords.left + "");
        });
    });
}