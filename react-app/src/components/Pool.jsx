import { useState } from "react";
import {
  PageContainer,
  PoolName,
  PageContent,
  ContentBox,
  PoolSource,
  PoolHost,
  PageLink,
  PoolBio,
  JoinButton,
  BackArrow,
  JoinedDiv,
} from "../styled/Pool";
import PoolTable from "./PoolTable";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faArrowLeft,
  faHighlighter,
  faArrowPointer,
  faCheck,
} from "@fortawesome/free-solid-svg-icons";

export default function Pool(props) {
  const [hostHightlighted, setHostHightlighted] = useState(false);

  const infoBackgroundColor = {
    backgroundColor: "rgba(131, 192, 193, 0.51)",
    boxShadow: "3px 3px 2px #83c0c1",
  };

  // Event handler to join a pool
  function handleRequestToJoin(e) {
    if (e.target.innerText === "Request to Join") {
      // Add database call to Request to Join
    }
  }

  return (
    <PageContainer>
      <BackArrow icon={faArrowLeft} onClick={props.onClick} />
      <PoolName>{props.data["0"]["Pool"]}</PoolName>
      <PageContent>
        <ContentBox style={infoBackgroundColor}>
          <PoolSource>
            Pool from{" "}
            <PageLink href={props.data["0"]["SourceLink"]} target="_blank">
              {props.data["0"]["SourceName"]}
            </PageLink>
          </PoolSource>
          <PoolHost>
            Host:{" "}
            <PageLink
              onMouseEnter={() => setHostHightlighted(true)}
              onMouseLeave={() => setHostHightlighted(false)}
            >
              {props.data["0"]["Host"]}
              <FontAwesomeIcon icon={faHighlighter} />
            </PageLink>
          </PoolHost>
          <PoolBio>{props.data["0"]["Bio"]}</PoolBio>
          {props.data["0"]["Host"] === "abutler" ? (
            <JoinedDiv disabled="disabled">
              Joined
              <FontAwesomeIcon style={{ marginLeft: "1rem" }} icon={faCheck} />
            </JoinedDiv>
          ) : (
            <JoinButton onClick={handleRequestToJoin}>
              Request to Join
              <FontAwesomeIcon
                style={{ marginLeft: "1rem" }}
                icon={faArrowPointer}
              />
            </JoinButton>
          )}
        </ContentBox>
        <ContentBox>
          <PoolSource>Leaderboard</PoolSource>
          <PoolTable tableData={props.data} highlightState={hostHightlighted} />
        </ContentBox>
      </PageContent>
    </PageContainer>
  );
}
