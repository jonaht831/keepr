<template>
    <div class="login pt-5">
        <form v-if="loginForm" @submit.prevent="loginUser">
            <div><input type="email" v-model="creds.email" placeholder="email"></div>
            <div><input type="password" v-model="creds.password" placeholder="password"></div>
            <button class="btn btn-info" type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit" class="btn btn-info">Create Account</button>
        </form>
        <div class="hover" @click="loginForm = !loginForm">
            <p v-if="loginForm">No account? Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
    </div>
</template>

<script>
    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>
<style>
    p {
        color: whitesmoke;
    }

    .hover {
        cursor: pointer;
    }
</style>