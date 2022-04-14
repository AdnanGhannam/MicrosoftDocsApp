function handleOnBlur(selector, action) {
    window.addEventListener('mouseup', (e) => {
        let box = document.querySelector(selector);

        if (box && !box.contains(e.target) && typeof(action) == "function") {
            action();
        }
    });
}

function checkOverflow(selector) {
    let el = document.querySelector(selector);

    if (el) {
        let curOverflow = el.style.overflow;

        if (!curOverflow || curOverflow === "visible")
            el.style.overflow = "hidden";

        let isOverflowing = el.clientWidth < el.scrollWidth
            || el.clientHeight < el.scrollHeight;

        el.style.overflow = curOverflow;

        return isOverflowing;
    }

    return false;
}

function handleClickOutsideMenu(id) {
    handleOnBlur('[data-id="' + id + '"]', () => {
        let checkbox = document.getElementById("menu-cb-" + id);

        if (checkbox) {
            checkbox.checked = false;
        }
    });
}

