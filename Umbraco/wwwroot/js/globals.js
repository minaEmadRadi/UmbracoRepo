const BlogGlobals = {
    api: {
        endpoints: {
            content: '/umbraco/delivery/api/v2/content'
        },
        headers: {
            apiKey: 'Mina-Emad-Radi'
        }
    },

    pagination: {
        itemsPerPage: 3,
        defaultPage: 1
    },
    umbraco: {
        imageCroplistAlias: 'Listing',
        itemAlias: 'blogItem'
    },
    localization: {
        translations: {
            'en': {
                next: 'Next →',
                back: '← Back',
                errors: {
                    loadFailed: 'Failed to load data. Please try again later.',
                    invalidData: 'Invalid data received from server'
                }
            },
            'ar': {
                next: 'التالي ←',
                back: '→ السابق',
                errors: {
                    loadFailed: 'فشل تحميل البيانات. يرجى المحاولة مرة أخرى لاحقاً',
                    invalidData: 'تم استلام بيانات غير صالحة من الخادم'
                }
            }
        }        
    }
};

Object.freeze(BlogGlobals);