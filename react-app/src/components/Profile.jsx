import { useState, useEffect } from "react";
import { fetchData } from "../services/apiService";
import {
  ProfileTitle,
  ProfileHeading,
  Container,
  Column,
  UserForm,
  Input,
  Button,
} from "../styled/Profile.js";

export default function Profile() {
  const [data, setData] = useState([]);
  const infoBackgroundColor = {
    backgroundColor: "rgba(131, 192, 193, 0.51)",
    boxShadow: "3px 3px 2px #83c0c1",
  };

  // Fetching data on initial load to populate user data update fields
  useEffect(() => {
    async function getData() {
      try {
        const response = await fetchData("getProfile", "abutler");
        if (response) {
          setData((prevData) => [...prevData, response]);
        }
      } catch (err) {
        console.error(`Error fetching items: ${err}`);
      }
    }
    getData();
  }, []);

  // Updating fields when data is populated or updated
  useEffect(() => {
    if (data.length > 0 && data[0].length > 0) {
      const formElements = document.getElementsByClassName("userData");
      Array.from(formElements).forEach((element) => {
        if (element.placeholder === "") {
          if (element.id === "Password") {
            element.placeholder = "*".repeat(data[0]["0"]["Password"].length); // Repeats password symbol for length of password
          } else {
            element.placeholder = data[0]["0"][element.id];
          }
        }
      });
    }
  }, [data]);

  // Adding updated elements to database upon user submission
  async function handleFormSubmission(e) {
    var dbValues = "";
    Array.from(e.target.elements).forEach((element) => {
      if (
        element.value.length > 0 &&
        element.value !== data[0]["0"][element.id]
      ) {
        // Change split character
        dbValues += `${element.id}/${element.value}/${data[0]["0"]["Username"]}/`;
        setData((prevArr) => {
          var modifiedValue = prevArr;
          modifiedValue[0]["0"][element.id] = element.value;
          return modifiedValue;
        });
      }
    });
    if (dbValues.length > 0) {
      const response = await fetchData(
        "updateUser",
        dbValues.substring(0, dbValues.length - 1)
      );
    }
  }

  return (
    <div>
      <div
        style={{
          display: data.length > 0 && data[0].length > 0 ? "flex" : "none",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <ProfileTitle>Profile</ProfileTitle>
        <Container>
          <Column style={infoBackgroundColor}>
            <ProfileHeading>Edit Account Details</ProfileHeading>
            <UserForm onSubmit={handleFormSubmission}>
              <label>
                Name: <Input type="text" id="Name" className="userData" />
              </label>
              <label>
                Username:
                <Input type="text" id="Username" className="userData" />
              </label>
              <label>
                Password:
                <Input type="password" id="Password" className="userData" />
              </label>
              <Button type="submit">Confirm Changes</Button>
            </UserForm>
          </Column>
          <Column>
            <ProfileHeading>Pool Memberships</ProfileHeading>
            <p>
              Click on button to view current memberships and edit your join
              status.
            </p>
            <Button>View Memberships</Button>
            <div>
              <p>Memberships will appear here.</p>
            </div>
          </Column>
        </Container>
      </div>
      <div
        style={{
          display: data.length > 0 && data[0].length > 0 ? "none" : "flex",
        }}
      >
        <ProfileTitle>
          Please Sign Up or Login to Access Profile Information.
        </ProfileTitle>
      </div>
    </div>
  );
}
