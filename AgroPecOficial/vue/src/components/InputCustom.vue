<template>
    <div>
      <label :for="id">{{ label }}</label>
      <input
        :id="id"
        :type="type"
        :value="modelValue"
        @input="$emit('update:modelValue', $event.target.value)"
        :placeholder="placeholder"
        :class="inputClass"
      />
    </div>
  </template>
  
  <script setup>
  import { defineProps, defineEmits } from 'vue'
  
  const props = defineProps({
    modelValue: {
      type: [String, Number], // Aceita tanto String quanto Number
      required: true,
  },
    label: String,
    placeholder: String,
    id: String,
    type: {
      type: String,
      default: 'text',
  },
    inputClass: String,
});
  
  const emit = defineEmits(['update:modelValue'])
  </script>
  
  <style scoped>
  input {
    padding: 10px;
    font-size: .8rem;
    border: 1px solid #ccccccc5;
    border-radius: .5rem;
    width: 100%;
  }
  
  input:focus {
    outline: none;
    border-color: #2c5c1865;
  }

  input::placeholder{
    color: rgba(0, 0, 0, 0.596);
    padding-left: .4rem;
  }
  </style>
