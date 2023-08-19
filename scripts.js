export function GetTelegramBotApiVersion() {
    return window.Telegram.WebApp.version;
}

export function Expand() {
    window.Telegram.WebApp.expand();
}

export function Close() {
    window.Telegram.close();
}