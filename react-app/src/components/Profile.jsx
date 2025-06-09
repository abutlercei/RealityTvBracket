import { useState, useEffect } from "react";
import { fetchData } from "../services/apiService";

export default function Profile() {
  const headingStyle = {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  };

  const [data, setData] = useState([]);
  useEffect(() => {
    async function getData() {
      try {
        const response = await fetchData("getProfile");
        setData((prevData) => [...prevData, response]);
      } catch (err) {
        console.error(`Error fetching items: ${err}`);
      }
    }

    getData();
  }, []);

  useEffect(() => console.log(data), [data]);

  return (
    <div style={headingStyle}>
      <h1>Profile</h1>
    </div>
  );
}
