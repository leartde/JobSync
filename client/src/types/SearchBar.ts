export type SearchBarProps = {
    placeholder: string;
    updateParameters: (params: { SearchTerm: string; PageNumber: number }) => void;
}