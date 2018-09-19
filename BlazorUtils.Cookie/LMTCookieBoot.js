window.LMTCookie = {};
window.LMTCookie.SessionStorage = {};
window.LMTCookie.SessionStorage.Get = (key) => {
    return eval(`window.sessionStorage.${key}`);
};