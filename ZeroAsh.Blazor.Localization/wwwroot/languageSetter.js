export const setLocalization = (value) => window.localStorage['BlazorCulture'] = value;
export const getLocalization = () => window.localStorage['BlazorCulture'];