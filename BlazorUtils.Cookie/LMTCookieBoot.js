window.LMTCookieBoot2 = {};
window.LMTCookieBoot2.SessionStorage = {};
window.LMTCookieBoot2.SessionStorage.Get = (key) => {
    return eval(`window.sessionStorage.${key}`);
};