import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import GlobalStyle from "./GlobalStyle";
import NavigationBar from "./components/NavigationBar";
import Home from "./components/Home";
import Search from "./components/Search";
import Profile from "./components/Profile";

export default function App() {
  library.add(fas); // Importing icons used in project

  return (
    <Router>
      <GlobalStyle />
      <NavigationBar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/search" element={<Search />} />
        <Route path="/profile" element={<Profile />} />
      </Routes>
    </Router>
  );
}
