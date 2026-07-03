function getHtmlFromContentEditable(elementId)
{
    const element = document.getElementById(elementId);
    if (element) {
        return element.innerText;
    }
    return null;
}

function setHtmlToContentEditable(elementId, text)
{
    const element = document.getElementById(elementId);
    if (element) {
        element.innerHtml = text;
    }
}

function removeFormattingWhilePasting(elementId)
{
    const element = document.getElementById(elementId);
    if (element) {
        element.onpaste = function (e) {
            e.preventDefault();
            const text = e.clipboardData.getData('text/plain');
            element.innerHTML = text;
        }
    }
}