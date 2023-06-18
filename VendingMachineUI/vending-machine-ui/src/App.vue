<template>
  <!-- The main application container -->
  <div id="app">
    <!-- Navigation bar -->
    <nav>
      <!-- Link to the dashboard -->
      <router-link to="/">Dashboard</router-link>
    </nav>

    <!-- The router view to render the appropriate component -->
    <router-view />
  </div>
</template>

<style>
/* Styling for the main application container */
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

/* Styling for the navigation bar */
nav {
  padding: 30px;
}

/* Styling for the navigation links */
nav a {
  font-weight: bold;
  color: #2c3e50;
}

/* Styling for the active navigation link */
nav a.router-link-exact-active {
  color: #42b983;
}
</style>
