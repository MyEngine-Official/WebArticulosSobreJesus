window.localStorageHelper = {
    getItem: function (key) {
        return localStorage.getItem(key);
    },
    setItem: function (key, value) {
        localStorage.setItem(key, value);
    },
    removeItem: function (key) {
        localStorage.removeItem(key);
    }
};

// Scroll to heading for table of contents
window.scrollToHeading = function (headingId) {
    // Find the heading by looking for matching text content
    const headings = document.querySelectorAll('.article-body h1, .article-body h2, .article-body h3, .article-body h4, .article-body h5, .article-body h6');
    
    for (const heading of headings) {
        const text = heading.textContent.trim().toLowerCase();
        const normalizedId = text.replace(/[^\w\s-]/g, '').replace(/\s+/g, '-');
        
        if (normalizedId === headingId || normalizedId.includes(headingId)) {
            heading.scrollIntoView({ behavior: 'smooth', block: 'start' });
            // Add a highlight effect
            heading.style.transition = 'background-color 0.3s ease';
            heading.style.backgroundColor = 'rgba(176, 42, 41, 0.1)';
            setTimeout(() => {
                heading.style.backgroundColor = '';
            }, 2000);
            break;
        }
    }
};
