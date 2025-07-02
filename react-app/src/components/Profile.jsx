import { useState, useEffect } from "react";
import { fetchData as fetchMembers } from "../services/memberService.js";
import {
  fetchData as fetchUsers,
  postData as postUser,
} from "../services/userService.js";
import {
  ProfileTitle,
  ProfileHeading,
  Container,
  Column,
  UserForm,
  Input,
  Button,
  MembershipContainer,
} from "../styled/Profile.js";
import PoolTable from "./PoolTable";

export default function Profile() {
  const [data, setData] = useState([]);
  const [table, setTable] = useState([]);
  const [viewMembership, setViewMembership] = useState(false);
  const [membershipFound, setMembershipFound] = useState(false);

  const infoBackgroundColor = {
    backgroundColor: "rgba(131, 192, 193, 0.51)",
    boxShadow: "3px 3px 2px #83c0c1",
  };
  const tableStyle = {
    margin: "2rem",
    padding: "2rem",
    outline: "1px",
    boxShadow: "3px 3px 2px black",
  };

  const username = "abutler";

  // Fetching data on initial load to populate user data update fields
  useEffect(() => {
    async function getData() {
      try {
        const response = await fetchUsers(username);
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
    if (data.length > 0) {
      const formElements = document.getElementsByClassName("userData");
      Array.from(formElements).forEach((element) => {
        if (
          element.placeholder === "" ||
          element.placeholder !== data["0"][element.id] ||
          element.value !== data["0"]["password"]
        ) {
          if (element.id === "password") {
            element.value = data["0"]["password"];
          } else {
            element.placeholder = data["0"][element.id];
          }
        }
      });
    }
  }, [data]);

  // Adding updated elements to database upon user submission
  async function handleFormSubmission(e) {
    let data = {
      Name:
        e.target.elements["name"].value === ""
          ? e.target.elements["name"].placeholder
          : e.target.elements["name"].value,
      Username:
        e.target.elements["username"].value === ""
          ? e.target.elements["username"].placeholder
          : e.target.elements["username"].value,
      Password: e.target.elements["password"].value,
    };
    const response = await postUser(data);
    setData(data);
  }

  // Changes member instructions and add/removes membership list
  async function handleViewMemberships() {
    var membershipElement = document.getElementsByClassName("memberships")[0];

    if (viewMembership) {
      setViewMembership(false);
      membershipElement.style.display = "none";
    } else {
      setViewMembership(true);
      try {
        const response = await fetchMembers(username);
        if (response) {
          let data = [];
          response.forEach((viewModel) => {
            data.push(viewModel);
          });

          setTable(data);
          setMembershipFound(true);
        }
      } catch (err) {
        setMembershipFound(false);
        console.error(`Error fetching items: ${err}`);
      }

      membershipElement.style.display = "flex";
    }
  }

  return (
    <div>
      <div
        style={{
          display: data.length > 0 ? "flex" : "none",
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
                Username:
                <Input
                  type="text"
                  id="username"
                  className="userData"
                  disabled="disabled"
                  style={{ backgroundColor: "slategray" }}
                />
              </label>
              <label>
                Name: <Input type="text" id="name" className="userData" />
              </label>
              <label>
                Password:
                <Input type="password" id="password" className="userData" />
              </label>
              <Button type="submit">Confirm Changes</Button>
            </UserForm>
          </Column>
          <Column>
            <ProfileHeading>Pool Memberships</ProfileHeading>
            <p>
              {viewMembership
                ? "Click on button to close memberships view."
                : "Click on button to view current memberships and edit your join status."}
            </p>
            <Button onClick={handleViewMemberships}>
              {viewMembership ? "Close Memberships" : "View Memberships"}
            </Button>
            <MembershipContainer
              className="memberships"
              style={{ display: viewMembership ? "flex" : "none" }}
            >
              {membershipFound ? (
                <PoolTable tableData={table} style={tableStyle} />
              ) : (
                <h3>No pools joined currently!</h3>
              )}
            </MembershipContainer>
          </Column>
        </Container>
      </div>
      <div
        style={{
          display: data.length > 0 ? "none" : "flex",
        }}
      >
        <ProfileTitle>
          Please Sign Up or Login to Access Profile Information.
        </ProfileTitle>
      </div>
    </div>
  );
}
