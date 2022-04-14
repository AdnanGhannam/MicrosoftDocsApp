function handleOnBlur(selector, action) {
    window.addEventListener('mouseup', (e) => {
        let box = document.querySelector(selector);

        if (box && !box.contains(e.target) && typeof(action) == "function") {
            action();
        }
    });
}

function handleClickOutsideMenu(id) {
    handleOnBlur('[data-id="' + id + '"]', () => {
        let checkbox = document.getElementById("menu-cb-" + id);

        if (checkbox) {
            checkbox.checked = false;
        }
    });
}

