<template>
  <div class="chat-container">
    <h2>Real-Time Chat</h2>

    <div class="messages">
      <div v-for="(msg, index) in messages" :key="index">
        <strong>{{ msg.user }}</strong
        >: {{ msg.message }}
      </div>
    </div>

    <form @submit.prevent="sendMessage">
      <input type="text" v-model="username" placeholder="Your name" required />
      <input type="text" v-model="message" placeholder="Type a message" required />
      <button type="submit">Send</button>
    </form>
  </div>
</template>

<script setup>
import { ref, onMounted, getCurrentInstance } from 'vue'

const username = ref('')
const message = ref('')
const messages = ref([])

// SignalR bağlantısını global olarak al
const instance = getCurrentInstance()
const signalR = instance.appContext.config.globalProperties.$signalR

const sendMessage = async () => {
  if (username.value && message.value) {
    await signalR.invoke('SendMessage', username.value, message.value)
    message.value = '' // Mesaj gönderildikten sonra input temizlenir
  }
}

onMounted(() => {
  // SignalR bağlantısını başlat
  signalR
    .start()
    .then(() => {
      console.log('SignalR bağlantısı başarılı!')
    })
    .catch((err) => console.error('Bağlantı hatası:', err))

  // Mesajları dinle
  signalR.on('ReceiveMessage', (user, msg) => {
    messages.value.push({ user, message: msg })
  })
})
</script>

<style>
.chat-container {
  width: 400px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 10px;
  background-color: #f9f9f9;
}
.messages {
  height: 200px;
  overflow-y: scroll;
  margin-bottom: 20px;
  border: 1px solid #ccc;
  padding: 10px;
  border-radius: 5px;
}
form input {
  margin-right: 10px;
  padding: 5px;
}
form button {
  padding: 5px 10px;
}
</style>
