export const separateCamelCase = (str: string | undefined): string => {
    if (!str) return ''
    return str.replace(/([A-Z])/g, ' $1').trim();
};