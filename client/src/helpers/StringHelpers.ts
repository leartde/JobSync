export const separateCamelCase = (str: string | undefined): string => {
    if (!str) return '';
    return str
        .replace(/([a-z])([A-Z])/g, '$1 $2') // Add space between camelCase
        .replace(/([A-Z]{2,})([A-Z][a-z])/g, '$1 $2') // Handle acronym followed by camelCase
        .trim();
};