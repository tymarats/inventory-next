export {};

// CxJS compiles `<cx>` blocks with its own factory. React's typings are what TypeScript resolves the
// JSX namespace from — cx-react pulls them in — so the element is declared there rather than in a
// global namespace, where the augmentation would not merge.
declare module "react" {
    namespace JSX {
        interface IntrinsicElements {
            cx: Record<string, unknown>;
        }
    }
}
