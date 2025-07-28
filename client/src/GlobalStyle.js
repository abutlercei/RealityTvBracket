import { createGlobalStyle } from "styled-components";
import "@fontsource/open-sans";
import "@fontsource/raleway";

const GlobalStyle = createGlobalStyle`
  html, body {
    font-family: "Open Sans", sans-serif;
  }

  h1, h2 {
    font-family: "Raleway", sans-serif;
  }
`;
export default GlobalStyle;
