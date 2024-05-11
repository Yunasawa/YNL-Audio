<h1><div align="center"><i> Audio Barrier </i><img height="30px" position="" src="https://github.com/Yunasawa/YNL-Audio/assets/113672166/2bb91d4e-d811-472a-800c-e34a62a59ed7" alt="script"></div></h1>

<h3> ★ Description </h3>

<ul>
  <li> Audio Barrier works in both 2D and 3D, it make a boudary to prevent Audio Sources to follow player. </li>
  <li><i> Audio Sources Interaction: </i></li>
  <ul>
    <li> Imagine you have an Audio Source, such as the sound of rain. </li>
    <li> When the player is outside the defined boundary, the rain sound follows them seamlessly. </li>
    <li> However, as soon as the player steps inside a house or any other enclosed space, the audio begins to change dynamically. </li>
  </ul>
  <li><i> Dynamic Audio Effects: </i></li>
  <ul>
    <li> Attenuation: As the player moves deeper into the enclosed space, the rain sound gradually becomes quieter. </li>
    <li> Wall Interaction: When the player approaches a wall that connects to the outside (where the rain is falling), the sound becomes louder. </li>
  </ul>
  <li> Whether it’s rain, footsteps, or other environmental sounds, the tool ensures that audio behaves authentically based on the player’s position relative to the defined boundaries. </li>
</ul>

<h3> ★ Sample </h3>

<table>
  <tr>
    <th width="50%"><video src="https://github.com/Yunasawa/YNL-Audio/assets/113672166/66f0ae1f-47d8-495c-b3b0-19fe04c001ed" alt="hello"></video></th>
    <th width="50%"><video src="https://github.com/Yunasawa/YNL-Audio/assets/113672166/1a047054-1a4f-4a0f-9e4d-7a32b9db84b6" alt="aaa"></video></th>
  </tr>
</table>

<ul>
  <li> You can find sample scene from <code> Packages/YNL - Audio/Extensions/Audio Barrier/Samples </code> </li>
  <li> Normally, you are not allowed to open the scene in a read-only package, but you can copy the scene and paste into a folder inside Assets, where you have full permission to open the scene. </li>
</ul>

<h3> ★ Instruction </h3>

<ul>
  <li> If you want to create a Barrier yourself, you can follow this instruction. </li>
  <li><i> Step 1: </i></li>
  <ul>
    <li> Create an empty object inside Hierarchy, then add component <code> Audio Barrier </code> into it. </li>
    <li> Choose the barrier type and size as you want. </li>
  </ul>
  <li><i> Step 2: </i></li>
  <ul>
    <li> Remove <code> Audio Listener </code> from your Camera. </li>
    <li> Create an empty object to be child of Camera or Player (wherever you want the Listener to be) and add a component <code> Audio Listener Setup </code>. It will automatically add an <code> Audio Listener </code> and a tag into the object.</li>
    <li> Create another empty object (same place with Audio Listener) and add a component <code> Audio Source Setup </code>. It will automatically add an <code> Audio Source </code> and a tag into the object. You can also add more <code> Audio Source </code> if you want to this object. </li>
  </ul>
  <li> And now you done, you can play the game to check if everything are perfect. </li>
</ul>
