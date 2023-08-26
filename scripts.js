export function WebAppVersion() {
    return window.Telegram.WebApp.version;
}

export function WebAppPlatform() {
    return window.Telegram.WebApp.platform;
}

export function WebAppIsExpanded() {
    return window.Telegram.WebApp.isExpanded;
}

export function WebAppExpand() {
    window.Telegram.WebApp.expand();
}

export function WebAppClose() {
    window.Telegram.WebApp.close();
}