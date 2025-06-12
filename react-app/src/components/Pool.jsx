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
  HighlightHostIcon,
} from "../styled/Pool";
import PoolTable from "./PoolTable";
import { faArrowLeft, faHighlighter } from "@fortawesome/free-solid-svg-icons";

export default function Pool(props) {
  const [hostHightlighted, setHostHightlighted] = useState(false);

  const infoBackgroundColor = {
    backgroundColor: "rgba(131, 192, 193, 0.51)",
    boxShadow: "3px 3px 2px #83c0c1",
  };

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
              <HighlightHostIcon icon={faHighlighter} />
            </PageLink>
          </PoolHost>
          <PoolBio>{props.data["0"]["Bio"]}</PoolBio>
          <JoinButton>Request to Join</JoinButton>
        </ContentBox>
        <ContentBox>
          <PoolSource>Leaderboard</PoolSource>
          <PoolTable tableData={props.data} highlightState={hostHightlighted} />
        </ContentBox>
      </PageContent>
    </PageContainer>
  );
}
