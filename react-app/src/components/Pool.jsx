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
} from "../styled/Pool";
import PoolTable from "./PoolTable";

export default function Pool() {
  const infoBackgroundColor = {
    backgroundColor: "rgba(131, 192, 193, 0.51)",
    boxShadow: "3px 3px 2px #83c0c1",
  };
  const tableData = [
    { Rank: 1, Name: "Rosalind", Contestant: "Richard", Points: 15 },
    { Rank: 2, Name: "Jeff", Contestant: "Kelly", Points: 14 },
    { Rank: 3, Name: "Cecile", Contestant: "Rudy", Points: 13 },
    { Rank: 4, Name: "Nina", Contestant: "Susan", Points: 12 },
    { Rank: 5, Name: "Patrica", Contestant: "Sean", Points: 11 },
    { Rank: 6, Name: "Kelley", Contestant: "Coleen", Points: 10 },
    { Rank: 7, Name: "Jayden", Contestant: "Gervase", Points: 9 },
    { Rank: 8, Name: "Taylor", Contestant: "Jenna", Points: 8 },
    { Rank: 9, Name: "Paris", Contestant: "Greg", Points: 7 },
    { Rank: 10, Name: "Kathleen", Contestant: "Gretchen", Points: 6 },
    { Rank: 11, Name: "Adam", Contestant: "Joel", Points: 5 },
    { Rank: 12, Name: "Stephan", Contestant: "Dirk", Points: 4 },
    { Rank: 13, Name: "Francis", Contestant: "Ramona", Points: 3 },
    { Rank: 14, Name: "April", Contestant: "Stacey", Points: 2 },
    { Rank: 15, Name: "Lucy", Contestant: "BB", Points: 1 },
    { Rank: 16, Name: "Morgan", Contestant: "Sonja", Points: 0 },
  ];

  return (
    <PageContainer>
      <PoolName>Lone Survivors (Pool Name)</PoolName>
      <PageContent>
        <ContentBox style={infoBackgroundColor}>
          <PoolSource>
            Pool from{" "}
            <PageLink
              href="https://en.wikipedia.org/wiki/Survivor:_Borneo"
              target="_blank"
            >
              Survivor Season 1
            </PageLink>
          </PoolSource>
          <PoolHost>
            Host: <PageLink href="./profile">abutler</PageLink>
          </PoolHost>
          <PoolBio>
            Join this test league to see other features within the environment.
            As Survivor Season 1 aired in 2000, this current league is closed
            for actual participants. This pool shows a type where participants
            gain points as their contestant stays in the competition. The other
            type of pool allows players to guess when contestants get eliminated
            similar to NCAA brackets.
          </PoolBio>
          <JoinButton>Request to Join</JoinButton>
        </ContentBox>
        <ContentBox>
          <PoolSource>Leaderboard</PoolSource>
          <PoolTable tableData={tableData} />
        </ContentBox>
      </PageContent>
    </PageContainer>
  );
}
