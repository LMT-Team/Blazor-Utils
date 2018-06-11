//BlazorUtils 0.1
//If a jQuery method has both get and set function, add number 2 after function name of the "get" one

function BlazorBoot() {
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
    function BlazorUtilsCallCSEnumerableCallBacks(id, ind, className) {
        const assemblyName = 'BlazorUtils.Dom';
        const namespace = 'BlazorUtils.Dom.Storages';
        const typeName = 'EnumerableCallBacksStorage';
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
    function BlazorUtilsCallCSEnumerableCallBacks2(id, ind, value, typeOfRet) {
        const assemblyName = 'BlazorUtils.Dom';
        const namespace = 'BlazorUtils.Dom.Storages';
        let typeName;
        if (typeOfRet === "string")
            typeName = 'EnumerableCallBacks4Storage';
        else
            typeName = 'EnumerableCallBacks3Storage';
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
            return BlazorUtilsCallCSEnumerableCallBacks(id, ind + "", className);
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
            return BlazorUtilsCallCSEnumerableCallBacks(id, ind + "", className);
        });
    });

    Blazor.registerFunction('LMTToggleClass4', function (selector, id, state) {
        $(selector).toggleClass((ind, className) => {
            return BlazorUtilsCallCSEnumerableCallBacks(id, ind + "", className);
        }, state);
    });

    Blazor.registerFunction('LMTHeight2', function (selector) {
        return $(selector).height();
    });

    Blazor.registerFunction('LMTHeight', function (selector, value) {
        $(selector).height(value);
    });

    Blazor.registerFunction('LMTHeightFunc1', function (selector, id) {
        return $(selector).height((ind, height) => {
            return BlazorUtilsCallCSEnumerableCallBacks2(id, ind + "", height + "", "number");
        });
    });

    Blazor.registerFunction('LMTHeightFunc2', function (selector, id) {
        return $(selector).height((ind, height) => {
            return BlazorUtilsCallCSEnumerableCallBacks2(id, ind + "", height + "", "string");
        });
    });
}