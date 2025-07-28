import {
  IntroductionContainer,
  FeatureContainer,
  Feature,
  Circle,
  FeatureDescription,
} from "../styled/Introduction";
import Xarrow from "react-xarrows";

export default function Introduction() {
  return (
    <IntroductionContainer>
      <h1 style={{ marginBottom: "3rem" }}>Welcome to Reality Fights!</h1>
      <FeatureContainer>
        <Feature id="box1">
          <Circle>
            <h1>1</h1>
          </Circle>
          <FeatureDescription>
            Pick a reality show or find a pool to join!
          </FeatureDescription>
        </Feature>
        <Feature id="box2">
          <Circle>
            <h1>2</h1>
          </Circle>
          <FeatureDescription>
            Join the pool and receive a single contestant or pick the order
            contestants will place!
          </FeatureDescription>
        </Feature>
        <Xarrow start="box1" end="box2" color="#6962ad" />
        <Feature id="box3">
          <Circle>
            <h1>3</h1>
          </Circle>
          <FeatureDescription>
            Create an account to access your pools and more features!
          </FeatureDescription>
        </Feature>
        <Xarrow start="box2" end="box3" color="#6962ad" />
      </FeatureContainer>
    </IntroductionContainer>
  );
}
