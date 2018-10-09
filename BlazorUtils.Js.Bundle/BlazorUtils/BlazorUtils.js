/*!
  * LMT Blazor Utils Js library v4.4.4
  * Copyright 2018 LMT
  * Licensed under MIT (https://github.com/15110123/Blazor-Utils/blob/master/LICENSE)
  */
//If a jQuery method has both get and set function, add number 2 after function name of the "get" one

window.blazorUtils = {
    core: {
        funcs:{

        }
    }
};
if (window.Blazor == undefined) {
    window.Blazor = {};
}

window.blazorUtils.core.s4 = () => {
    return Math.floor((1 + Math.random()) * 0x10000)
        .toString(16)
        .substring(1);
};

window.blazorUtils.core.guid = () => {
    //No symbol guid, reference: https://stackoverflow.com/questions/105034/create-guid-uuid-in-javascript
    return (
        window.blazorUtils.core.s4() +
        window.blazorUtils.core.s4() +
        "-" +
        window.blazorUtils.core.s4() +
        "-" +
        window.blazorUtils.core.s4() +
        "-" +
        window.blazorUtils.core.s4() +
        "-" +
        window.blazorUtils.core.s4() +
        window.blazorUtils.core.s4() +
        window.blazorUtils.core.s4()
    );
};

$(() => {
    //window.Blazor might be overrided if put outside of jQuery onLoad
    window.Blazor.registerFunction = (funcName, func) => {
        eval(`window.blazorUtils.core.funcs.${funcName} = ${Object.keys({ func })[0]}`);
    };

    LMTDomBoot();
    LMTCookieBoot();
});

function LMTCookieBoot() {
    //Reference to https://www.w3schools.com/js/js_cookies.asp
    let setCookie = (cname, cvalue, exdays, path) => {
        var expires = "";
        if (exdays != 0) {
            var d = new Date();
            d.setTime(d.getTime() + exdays * 24 * 60 * 60 * 1000);
            expires = ";expires=" + d.toUTCString();
        }
        document.cookie = cname + "=" + cvalue + expires + ";path=" + path;
    };

    Blazor.registerFunction("LMTCookies", function () {
        return document.cookie;
    });

    Blazor.registerFunction("LMTCookiesAdd", function (key, value, exp, path) {
        setCookie(key, value, exp, path);
    });

    Blazor.registerFunction("LocalStorageGet", key => {
        return localStorage.getItem(key);
    });

    Blazor.registerFunction("LocalStorageSet", (key, value) => {
        localStorage.setItem(key, value);
    });

    Blazor.registerFunction("LocalStorageRemove", key => {
        localStorage.removeItem(key);
    });

    Blazor.registerFunction("LocalStorageClear", () => {
        localStorage.clear();
    });

    Blazor.registerFunction("SessionStorageGet", key => {
        return sessionStorage.getItem(key);
    });

    Blazor.registerFunction("SessionStorageSet", (key, value) => {
        sessionStorage.setItem(key, value);
    });

    Blazor.registerFunction("SessionStorageRemove", key => {
        sessionStorage.removeItem(key);
    });

    Blazor.registerFunction("SessionStorageClear", () => {
        sessionStorage.clear();
    });
}

function LMTDomBoot() {
    //Behaviors
    Blazor.registerFunction("LMTBehavioursBoot", function func() {
        let boolParse = obj => {
            if (obj == null) return false;
            else return obj === "true";
        };

        let getValParse = (obj, defaultVal) => {
            if (obj == null || obj == "") return defaultVal;
            else return obj;
        };

        //Reference to https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/random
        let randomIntInclusive = (min, max) => {
            if (min > max) return NaN;

            min = Math.ceil(min);
            max = Math.floor(max);
            return Math.floor(Math.random() * (max - min + 1)) + min; //The maximum is inclusive and the minimum is inclusive
        };
        //lmt-grid
        $.each($("[lmt-grid]"), (ind, val) => {
            if (val.islmtgrid != undefined) return;
            val.islmtgrid = true;
            let param = val.getAttribute("lmt-grid").split(",");
            let isFluid = boolParse(val.getAttribute("lmt-grid-fluid"));
            val.className += isFluid ? " container-fluid" : " container";
            $.each($(val).children(), (ind, val) => {
                let rowChildren = $(val).children();
                val.className += " row";
                let isAutoWidth = rowChildren.length > param.length;
                $.each($(val).children(), (ind, val) => {
                    if (isAutoWidth) val.className += " col-" + param[0];
                    else val.className += " col-" + param[ind];
                });
            });
        });
        //lmt-draggable
        $("[lmt-drag]").draggable();
        //lmt-resize
        $("[lmt-resize]").resizable();
        //lmt-select
        $("[lmt-select]").selectable();
        //lmt-sort
        $("[lmt-sort]").sortable();
        //lmt-readonly
        $.each($("[lmt-readonly]"), (ind, val) => {
            $(val)
                .prop("readonly", true)
                .prop("title", val.getAttribute("lmt-readonly"))
                .tooltip();
        });
        //lmt-val-guid
        $("[lmt-val-guid]").val(() => {
            return blazorUtils.core.guid();
        });
        //lmt-val-num
        $.each($("[lmt-val-num]"), (ind, ele) => {
            let params = ele.getAttribute("lmt-val-num").split(",");
            ele.value = randomIntInclusive(parseInt(params[0]), parseInt(params[1]));
        });
        //lmt-accord
        $("[lmt-accord]").accordion({ heightStyle: "content" });
        //lmt-autocomp
        $.each($("[lmt-autocomp]"), (ind, ele) => {
            $(ele).autocomplete({
                source: ele.getAttribute("lmt-autocomp").split(",")
            });
        });
        //lmt-date
        $.each($("[lmt-date]"), (ind, ele) => {
            let dateFormat = getValParse(ele.getAttribute("lmt-date"), "mm/dd/yy");
            $(ele).datepicker({ dateFormat });
        });
        //lmt-dialog
        $.each($("[lmt-dialog]"), (ind, ele) => {
            if (ele.isDialog != undefined) return;
            ele.isDialog = true;
            let title = getValParse(ele.getAttribute("lmt-dialog"), "");
            $(ele).dialog({ title });
        });
        //lmt-tip
        $.each($("[lmt-tip]"), (ind, val) => {
            $(val)
                .prop("title", val.getAttribute("lmt-tip"))
                .tooltip();
        });
        //lmt-bm
        $.each($("[lmt-bm]"), function lmtbmFunc(ind, val) {
            if (val.islmtbm != undefined) return;
            val.islmtbm = true;
            let objName = getValParse(val.getAttribute("lmt-bm-name"), null);
            let speed = getValParse(val.getAttribute("lmt-bm-speed"), "1");
            let direction = getValParse(val.getAttribute("lmt-bm-direction"), "1");

            let animation = bodymovin.loadAnimation({
                container: val,
                renderer: "svg",
                loop: boolParse(val.getAttribute("lmt-bm-loop")),
                autoplay: false,
                path: val.getAttribute("lmt-bm")
            });

            animation.setSpeed(parseInt(speed));
            animation.setDirection(parseInt(direction));

            if (boolParse(getValParse(val.getAttribute("lmt-bm-autoplay"), "true"))) {
                animation.play();
            }

            if (objName != null) eval(`window.${objName} = animation`);
        });
        //lmt-filter
        $.each($("[lmt-filter]"), (ind, val) => {
            if (val.islmtfilter != undefined) return;
            val.islmtfilter = true;
            var colorRate = val.getAttribute("lmt-filter").split(",");
            val.style.position = "relative";
            $(val).append(
                `<div style="z-index: 20; position: absolute; background-color: ${
                colorRate[0]
                }; width: 100%; height: 100%; left: 0; top: 0; opacity: ${
                colorRate[1] ? colorRate[1] : "0.5"
                }"/>`
            );
        });
        //lmt-skeleton
        $.each($("[lmt-skeleton]"), (ind, ele) => {
            $.each($(ele.children), (childInd, childEle) => {
                if (childEle.islmtskeleton != undefined) return;
                childEle.islmtskeleton = true;
                $(childEle)
                    .css(
                        "background",
                        "linear-gradient(90deg, #ffffff, #d4d4d4, #ffffff)"
                    )
                    .css("background-size", "600% 600%");

                setInterval(() => {
                    $(childEle)
                        .css("background-position", "100%")
                        .animate(
                            {
                                backgroundPosition: "0%"
                            },
                            800,
                            "swing"
                        );
                }, 1000);
            });
        });
        //lmt-scroll
        $.each($("[lmt-scroll]"), (ind, val) => {
            if (val.islmtscroll != undefined) return;
            val.islmtscroll = true;
            let pxVal = val.getAttribute("lmt-scroll");
            val.addEventListener("click", () => {
                $("html").animate(
                    {
                        scrollTop: pxVal
                    },
                    1000
                );
            });
        });
        //lmt-scroll-to
        $.each($("[lmt-scroll-to]"), (ind, val) => {
            if (val.islmtscrollto != undefined) return;
            val.islmtscrollto = true;
            let selector = val.getAttribute("lmt-scroll-to");
            val.addEventListener("click", () => {
                $("html").animate(
                    {
                        scrollTop: $(selector).offset().top
                    },
                    1000
                );
            });
        });
        //lmt-scroll-move
        setTimeout(() => {
            $.each($("[lmt-scroll-move]"), (ind, ele) => {
                if (ele.lmtLeft != undefined) return;
                let moveDist = parseInt(ele.getAttribute("lmt-scroll-move"));
                let isMoveRight = moveDist >= 0;
                if (ele.style.left != "") {
                    ele.lmtLeft = parseInt(ele.style.left);
                } else if (ele.style.right != "") {
                    ele.lmtLeft =
                        ele.getBoundingClientRect().left -
                        ele.parentElement.getBoundingClientRect().left;
                } else {
                    ele.lmtLeft = 0;
                }
                window.addEventListener("scroll", () => {
                    let diff =
                        document.documentElement.clientHeight -
                        ele.getBoundingClientRect().top;
                    if (diff >= 0 && ele.getBoundingClientRect().bottom > 0) {
                        var dist = (diff / 2) * (isMoveRight ? 1 : -1);
                        if ((dist < 0 && dist < moveDist) || (dist >= 0 && dist > moveDist))
                            return;
                        ele.style.left = ele.lmtLeft + dist + "px";
                    }
                });
            });
        }, 500);
        //lmt-fx
        $.each($("[lmt-fx]"), (ind, ele) => {
            let params = getValParse(ele.getAttribute("lmt-fx"), "").split(",");
            if (params.length != 2) return;
            let dur = parseInt(
                getValParse(ele.getAttribute("lmt-fx-duration"), "500")
            );
            let fxDest = getValParse(ele.getAttribute("lmt-fx-to"), "");
            let className = getValParse(ele.getAttribute("lmt-fx-class"), "");
            let size = getValParse(ele.getAttribute("lmt-fx-size"), "200,60").split(
                ","
            );
            let percent = parseInt(
                getValParse(ele.getAttribute("lmt-fx-percent"), "50")
            );

            let options = {};
            if (params[0] === "scale") {
                options = { percent: percent };
            } else if (params[0] === "transfer") {
                options = { to: fxDest, className: className };
            } else if (params[0] === "size") {
                options = {
                    to: { width: parseInt(size[0]), height: parseInt(size[1]) }
                };
            }

            eval(
                `window.${params[1]} = () => {$(${Object.keys({ ele })[0]}).effect(${Object.keys({ params })[0]}[0], ${Object.keys({ options })[0]}, ${Object.keys({ dur })[0]})}`
            );
        });
    });

    //Reference to https://learn-blazor.com/architecture/interop/
    let BlazorUtilsCallCSUICallBack = id => {
        let result = DotNet.invokeMethod("BlazorUtils.Dom", "UICallBacksStorageInvoke", id).toString();

        if (result == "True") {
            return true;
        }
        return false;
    };

    let BlazorUtilsCallCSUICallBackWithFileData = (id, data, file) => {
        let result = DotNet.invokeMethod("BlazorUtils.Dom", "UICallBacksStorageInvokeWithFileData", id, data, `${file.lastModifiedDate.getFullYear().toString()}|${(
            file.lastModifiedDate.getMonth() + 1
        ).toString()}|${file.lastModifiedDate
            .getDate()
            .toString()}|${file.lastModifiedDate
                .getHours()
                .toString()}|${file.lastModifiedDate
                    .getMinutes()
                    .toString()}|${file.lastModifiedDate
                        .getSeconds()
                .toString()}|${file.lastModifiedDate.getMilliseconds().toString()}`,
            `${file.name}|${file.type}|${file.size.toString()}`).toString();

        if (result == "True") {
            return true;
        }
        return false;
    };

    let BlazorUtilsCallCSUICallBackWithStringData = (id, data) => {
        let result = DotNet.invokeMethod("BlazorUtils.Dom", "UICallBacksStorageInvokeWithStringData", id, data).toString();

        if (result == "True") {
            return true;
        }
        return false;
    };

    // ReSharper disable once InconsistentNaming
    let BlazorUtilsCallIntStringString = (id, ind, className) => {
        return DotNet.invokeMethod("BlazorUtils.Dom", "IntStringStringStorageInvoke", id, ind, className);
    };

    // ReSharper disable once InconsistentNaming
    let BlazorUtilsCallIntInt = (id, ind, value, typeOfRet) => {
        let typeName;
        if (typeOfRet === "string") typeName = "IntIntStringStorage";
        else typeName = "IntIntDoubleStorage";

        return DotNet.invokeMethod("BlazorUtils.Dom", `${typeName}Invoke`, id, ind, value);
    };

    // ReSharper disable once InconsistentNaming
    let BlazorUtilsCallIntDouble = (id, ind, value, typeOfRet) => {
        let typeName;
        if (typeOfRet === "string") typeName = "IntDoubleStringStorage";
        else typeName = "IntDoubleDoubleStorage";

        return DotNet.invokeMethod("BlazorUtils.Dom", `${typeName}Invoke`, id, ind, value);
    };

    let BlazorUtilsCallIntCoordsCoords = (id, ind, value1, value2) => {
        return JSON.parse(DotNet.invokeMethod("BlazorUtils.Dom", "IntCoordsCoordsStorageInvoke", id, ind, value1, value2));
    };

    //Pure Js
    Blazor.registerFunction("LMTDomEval", function (jsCode) {
        let result = eval(jsCode);
        let resultType = typeof result;
        return resultType == "function" ||
            result === undefined ||
            resultType == "date"
            ? null
            : result;
    });

    //jQuery

    Blazor.registerFunction("LMTDomToggle", function (selector) {
        $(selector).toggle(selector);
    });

    Blazor.registerFunction("LMTDomAttr", function (selector, attribute, value) {
        $(selector).attr(attribute, value);
    });

    Blazor.registerFunction("LMTDomAttr2", function (selector, attribute) {
        return $(selector).attr(attribute);
    });

    Blazor.registerFunction("LMTDomVal", function (selector, value) {
        $(selector).val(value);
    });

    Blazor.registerFunction("LMTDomVal2", function (selector) {
        return $(selector).val();
    });

    Blazor.registerFunction("LMTDomText", function (selector, text) {
        $(selector).text(text);
    });

    Blazor.registerFunction("LMTDomText2", function (selector) {
        return $(selector).text();
    });

    Blazor.registerFunction("LMTDomCss", function (selector, propertyName, value) {
        $(selector).css(propertyName, value);
    });

    Blazor.registerFunction("LMTDomCss2", function (selector, propertyName) {
        return $(selector).css(propertyName);
    });

    Blazor.registerFunction("LMTAnimate", function (
        selector,
        properties,
        duration,
        easing
    ) {
        $(selector).animate(properties, duration, easing);
    });

    Blazor.registerFunction("LMTAnimateOptions", function (
        selector,
        properties,
        options
    ) {
        $(selector).animate(properties, options);
    });

    Blazor.registerFunction("LMTOn", function (selector, events, handler) {
        $(selector).on(events, e => {
            let result = false;
            if (e.originalEvent && e.originalEvent.dataTransfer) {
                e.preventDefault();
                if (e.type == "drop") {
                    let files = e.originalEvent.dataTransfer.files;
                    if (files.length != 0) {
                        for (var i = 0, f; (f = files[i]); i++) {
                            let fileReader = new FileReader();
                            fileReader.file = f;
                            fileReader.readAsDataURL(f);
                            fileReader.onload = function () {
                                BlazorUtilsCallCSUICallBackWithFileData(
                                    handler,
                                    fileReader.result,
                                    fileReader.file
                                );
                            };
                        }
                    } else {
                        BlazorUtilsCallCSUICallBackWithStringData(
                            handler,
                            e.originalEvent.dataTransfer.getData("text")
                        );
                    }
                }
            } else {
                result = BlazorUtilsCallCSUICallBack(handler);
                if (e != null && result) e.preventDefault();
            }
        });
    });

    Blazor.registerFunction("LMTAdd", function (selector, arg) {
        $(selector).add(arg);
    });

    Blazor.registerFunction("LMTAddClass", function (selector, className) {
        $(selector).addClass(className);
    });

    Blazor.registerFunction("LMTHasClass", function (selector, className) {
        return $(selector).hasClass(className);
    });

    Blazor.registerFunction("LMTHtml", function (selector) {
        return $(selector).html();
    });

    Blazor.registerFunction("LMTProp", function (selector, propertyName) {
        return $(selector).prop(propertyName);
    });

    Blazor.registerFunction("LMTRemoveAttr", function (selector, attributeName) {
        return $(selector).removeAttr(attributeName);
    });

    Blazor.registerFunction("LMTRemoveClass", function (selector, className) {
        $(selector).removeClass(className);
    });

    Blazor.registerFunction("LMTRemoveClassFunc", function (selector, id) {
        $(selector).removeClass((ind, className) => {
            return BlazorUtilsCallIntStringString(id, ind + "", className);
        });
    });

    Blazor.registerFunction("LMTRemoveProp", function (selector, propertyName) {
        $(selector).removeProp(propertyName);
    });

    Blazor.registerFunction("LMTToggleClass1", function (selector, className) {
        $(selector).toggleClass(className);
    });

    Blazor.registerFunction("LMTToggleClass2", function (
        selector,
        className,
        state
    ) {
        $(selector).toggleClass(className, state);
    });

    Blazor.registerFunction("LMTToggleClass3", function (selector, id) {
        $(selector).toggleClass((ind, className) => {
            return BlazorUtilsCallIntStringString(id, ind + "", className);
        });
    });

    Blazor.registerFunction("LMTToggleClass4", function (selector, id, state) {
        $(selector).toggleClass((ind, className) => {
            return BlazorUtilsCallIntStringString(id, ind + "", className);
        }, state);
    });

    Blazor.registerFunction("LMTHeight2", function (selector) {
        return $(selector).height();
    });

    Blazor.registerFunction("LMTHeight", function (selector, value) {
        $(selector).height(value);
    });

    Blazor.registerFunction("LMTHeightFunc1", function (selector, id) {
        $(selector).height((ind, height) => {
            return BlazorUtilsCallIntInt(id, ind + "", height + "", "number");
        });
    });

    Blazor.registerFunction("LMTHeightFunc2", function (selector, id) {
        $(selector).height((ind, height) => {
            return BlazorUtilsCallIntInt(id, ind + "", height + "", "string");
        });
    });

    Blazor.registerFunction("LMTInnerHeight2", function (selector) {
        return $(selector).innerHeight();
    });

    Blazor.registerFunction("LMTInnerHeight", function (selector, value) {
        $(selector).innerHeight(value);
    });

    Blazor.registerFunction("LMTInnerHeightFunc1", function (selector, id) {
        $(selector).innerHeight((ind, height) => {
            return BlazorUtilsCallIntDouble(id, ind + "", height + "", "string");
        });
    });

    Blazor.registerFunction("LMTInnerHeightFunc2", function (selector, id) {
        $(selector).innerHeight((ind, height) => {
            return BlazorUtilsCallIntDouble(id, ind + "", height + "", "number");
        });
    });

    Blazor.registerFunction("LMTWidth2", function (selector) {
        return $(selector).width();
    });

    Blazor.registerFunction("LMTWidth", function (selector, value) {
        $(selector).width(value);
    });

    Blazor.registerFunction("LMTWidthFunc1", function (selector, id) {
        $(selector).width((ind, value) => {
            return BlazorUtilsCallIntInt(id, ind + "", value + "", "string");
        });
    });

    Blazor.registerFunction("LMTWidthFunc2", function (selector, id) {
        $(selector).width((ind, value) => {
            return BlazorUtilsCallIntInt(id, ind + "", value + "", "number");
        });
    });

    Blazor.registerFunction("LMTInnerWidth2", function (selector) {
        return $(selector).innerWidth();
    });

    Blazor.registerFunction("LMTInnerWidth", function (selector, value) {
        $(selector).innerWidth(value);
    });

    Blazor.registerFunction("LMTInnerWidthFunc1", function (selector, id) {
        $(selector).innerWidth((ind, width) => {
            return BlazorUtilsCallIntDouble(id, ind + "", width + "", "string");
        });
    });

    Blazor.registerFunction("LMTInnerWidthFunc2", function (selector, id) {
        $(selector).innerWidth((ind, width) => {
            return BlazorUtilsCallIntDouble(id, ind + "", width + "", "number");
        });
    });

    Blazor.registerFunction("LMTOffset2", function (selector) {
        return $(selector).offset();
    });

    Blazor.registerFunction("LMTOffset", function (selector, coordinates) {
        $(selector).offset(coordinates);
    });

    Blazor.registerFunction("LMTOffsetFunc", function (selector, id) {
        $(selector).offset((ind, coords) => {
            return BlazorUtilsCallIntCoordsCoords(
                id,
                ind + "",
                coords.top + "",
                coords.left + ""
            );
        });
    });

    Blazor.registerFunction("LMTOff", function (selector) {
        $(selector).off();
    });

    Blazor.registerFunction("LMTOffEvent", function (selector, event) {
        $(selector).off(event);
    });

    Blazor.registerFunction("LMTOuterHeightMargin", function (selector, includeMargin) {
        return $(selector).outerHeight(includeMargin);
    });

    Blazor.registerFunction("LMTOuterHeight", function (selector, value) {
        $(selector).outerHeight(value);
    });

    //String func
    Blazor.registerFunction("LMTOuterHeightFunc1", function (selector, id) {
        $(selector).outerHeight((ind, height) => {
            return BlazorUtilsCallIntDouble(id, ind + "", height + "", "string");
        });
    });

    //double func
    Blazor.registerFunction("LMTOuterHeightFunc2", function (selector, id) {
        $(selector).outerHeight((ind, height) => {
            return BlazorUtilsCallIntDouble(id, ind + "", height + "", "number");
        });
    });

    Blazor.registerFunction("LMTOuterWidth", function (selector, value) {
        $(selector).outerWidth(value);
    });

    Blazor.registerFunction("LMTOuterWidthMargin", function (selector, includeMargin) {
        return $(selector).outerWidth(includeMargin);
    });

    Blazor.registerFunction("LMTOuterWidthFunc1", function (selector, id) {
        $(selector).outerWidth((ind, width) => {
            return BlazorUtilsCallIntDouble(id, ind + "", width + "", "string");
        });
    });

    Blazor.registerFunction("LMTOuterWidthFunc2", function (selector, id) {
        $(selector).outerWidth((ind, width) => {
            return BlazorUtilsCallIntDouble(id, ind + "", width + "", "number");
        });
    });

    Blazor.registerFunction("LMTPosition", function (selector) {
        return $(selector).position();
    });

    Blazor.registerFunction("LMTScrollLeft2", function (selector) {
        return $(selector).scrollLeft();
    });

    Blazor.registerFunction("LMTScrollLeft", function (selector, value) {
        $(selector).scrollLeft(value);
    });

    Blazor.registerFunction("LMTScrollTop2", function (selector) {
        return $(selector).scrollTop();
    });

    Blazor.registerFunction("LMTScrollTop", function (selector, value) {
        $(selector).scrollTop(value);
    });
}
